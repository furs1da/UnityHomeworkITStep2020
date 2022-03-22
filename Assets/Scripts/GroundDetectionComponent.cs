using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void GroundedDelegate(Collider2D ground);
public delegate void AirborneDelegate();
public class GroundDetectionComponent : MonoBehaviour
{
    public event GroundedDelegate GroundedEvent;
    public event AirborneDelegate AirborneEvent;

    [SerializeField] LayerMask layerMask;
    [SerializeField] Vector2 overlapSize;

    Collider2D ground;


    private void Start()
    {
        GroundedEvent += x => Debug.Log("GroundedEvent " + x.name);
        AirborneEvent += () => Debug.Log("AirborneEvent");
    }
    public bool IsGrounded
    {
        get
        {
            return ground != null;
        }
    }
    private void Update()
    {
        Vector2 center = (Vector2)transform.position + Vector2.down * (0.5f + overlapSize.y / 2f);
        Collider2D newGround = Physics2D.OverlapBox(center, overlapSize, 0f, layerMask);

        if (newGround != null && ground == null)
        {
            ground = newGround;
            if (GroundedEvent != null)
            {
                GroundedEvent(ground);
            }
        }
        else if (newGround == null && ground != null)
        {
            ground = null;
            if (AirborneEvent != null)
            {
                AirborneEvent();
            }
        }
    }
}
