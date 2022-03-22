using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public GameObject player;
  
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Jump(float maxSpeed)
    {
        Vector2 tmp = rigidbody2D.velocity;
        tmp.y = maxSpeed;
        rigidbody2D.velocity = tmp;
    }
}
