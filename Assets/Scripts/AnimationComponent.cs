using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    MoveComponent moveComponent;
    GroundDetectionComponent detectionComponent;
    new Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        detectionComponent = GetComponent<GroundDetectionComponent>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveComponent = GetComponent<MoveComponent>();
        moveComponent.MoveEvent += MoveEvent;

        detectionComponent.GroundedEvent += GroundedEvent;
        detectionComponent.AirborneEvent += AirborneEvent;
    }
    private void AirborneEvent()
    {
        animator.SetBool("IsGrounded", false);
    }
    private void GroundedEvent(Collider2D ground)
    {
        animator.SetBool("IsGrounded", true);
    }
    private void MoveEvent(float direction, float maxSpeed)
    {
        animator.SetFloat("SpeedX", Mathf.Abs(direction * maxSpeed));
        if (direction != 0f)
            spriteRenderer.flipX = direction < 0f;
    }
    private void FixedUpdate()
    {
        animator.SetFloat("VelocityY", rigidbody2D.velocity.y);
    }
}
