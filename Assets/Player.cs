using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 10f;
    private Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("horizontalSpeed", Mathf.Abs(moveInput));

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&GroundController.isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    

    
}
