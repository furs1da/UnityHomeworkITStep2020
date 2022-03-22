using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MoveDelegate(float direction, float maxSpeed);
public class MoveComponent : MonoBehaviour
{
    public event MoveDelegate MoveEvent;
    new Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Move(float direction, float maxSpeed)
    {
        Vector2 tmp = rigidbody2D.velocity;
        tmp.x = direction * maxSpeed;
        rigidbody2D.velocity = tmp;

        if (MoveEvent != null)
            MoveEvent(direction, maxSpeed);
    }   
}
