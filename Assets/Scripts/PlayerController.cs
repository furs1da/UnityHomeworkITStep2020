using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] GameObject bulletPrefab;

    MoveComponent moveComponent;
    JumpComponent jumpComponent;
    ShootComponent shootComponent;
    GroundDetectionComponent detectionComponent;
    PauseMenuController pauseMenuController;
    float direction = 1f;
    void Start()
    {
        moveComponent = GetComponent<MoveComponent>();
        jumpComponent = GetComponent<JumpComponent>();
        shootComponent = GetComponent<ShootComponent>();
        detectionComponent = GetComponent<GroundDetectionComponent>();
        pauseMenuController = FindObjectOfType<PauseMenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuController.IsPaused)
            return;


        float hInput = Input.GetAxis("Horizontal");

        if (hInput != 0f)
            direction = Mathf.Sign(hInput);

        moveComponent.Move(hInput, moveSpeed);

        if (Input.GetButtonDown("Jump") && detectionComponent.IsGrounded)
        {
            jumpComponent.Jump(jumpForce);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            shootComponent.Shot(direction, 20f, bulletPrefab);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Platform"))
    //    {
    //        transform.parent = collision.transform;
    //        moveSpeed = moveSpeed + collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Platform"))
    //    {
    //        transform.parent = null;
    //        moveSpeed = 5f;
    //    }
    //}
}