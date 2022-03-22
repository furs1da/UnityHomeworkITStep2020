using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oppos : MonoBehaviour
{
    public Transform[] spots;
    public PlayerController player;
    private int numberOfSpots;
    public bool moveFrontToBack;
    public float moveSpeed = 5;
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
        moveSpeed = 5;
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
                Flip();
            }
            if (nextSpot == numberOfSpots)
            {
                nextSpot = 0;
               
            }
        }
    }
    private void Flip()
    {
        
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
}
