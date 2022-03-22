//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Platform : MonoBehaviour
//{
//    public Transform pos1, pos2;
//    public float speed;
//    public Transform startPos;
//    Vector3 nextPos;
//    void Start()
//    {
//        nextPos = startPos.position;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (transform.position == pos1.position)
//        {
//            nextPos = pos2.position;
//        }
//        if (transform.position == pos2.position)
//        { nextPos = pos1.position; }

//        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
//    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.DrawLine(pos1.position, pos2.position);
//    }
//    //private void OnCollisionEnter2D(Collision2D collision)
//    //{
    //if (collision.gameObject.tag == "Player")
    //{
    //    collision.collider.transform.SetParent(transform);
     
    //}
//    //}
//    //private void OnCollisionExit2D(Collision2D collision)
//    //{
//    //    if (collision.gameObject.tag == "Player")
//    //    {
//    //        collision.collider.transform.SetParent(null);
//    //    }
//    //}

//}


using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Platform : MonoBehaviour
{

    public Transform[] spots;
    public PlayerController player;
    private int numberOfSpots;
    public bool moveFrontToBack;
    public float moveSpeed;
    public float waitTime;
    private float delay;
    private int nextSpot;
    private bool goForward;

    void Start()
    {
        gameObject.transform.position = spots[0].transform.position;
        numberOfSpots = spots.Length;
        nextSpot = 0;
        delay = waitTime;
        goForward = true;
    }
    void Update()
    {
        // moves object to next point
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, spots[nextSpot].transform.position, moveSpeed * Time.deltaTime);

        // starts delay timer when at assigned point
        if (gameObject.transform.position == spots[nextSpot].transform.position && delay > 0)
        {
            delay -= Time.deltaTime;
        }
        // Move from point a to b to c to b to a
        if (moveFrontToBack)
        {
            // assigns next point
            if (delay <= 0 && gameObject.transform.position == spots[nextSpot].transform.position && goForward)
            {
                nextSpot += 1;
                delay = waitTime;
            }

            if (delay <= 0 && gameObject.transform.position == spots[nextSpot].transform.position && !goForward)
            {
                nextSpot -= 1;
                delay = waitTime;
            }
            // checks if at the end of trail or beginging
            if (nextSpot == numberOfSpots - 1)
            {
                goForward = false;
            }
            if (nextSpot == 0)
            {
                goForward = true;
            }
        }
        // once the platform reaches the final spot, go back to the first spot
        if (!moveFrontToBack)
        {
            // assigns next point
            if (delay <= 0 && gameObject.transform.position == spots[nextSpot].transform.position)
            {
                nextSpot += 1;
                delay = waitTime;
            }
            if (nextSpot == numberOfSpots)
            {
                nextSpot = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
    {
        collision.collider.transform.SetParent(transform);

    }
        }
        private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        collision.collider.transform.SetParent(null);
    }
}
}