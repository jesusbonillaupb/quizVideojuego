using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float jumpForce = 8f;
    private Animator animator;

    private Rigidbody2D rb;
    public SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        FlipSprite(); // Added function to handle sprite flipping
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("horizontalSpeed", Mathf.Abs(moveInput));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundController.isGrounded) // Assuming GroundController script exists
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void FlipSprite()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Flip sprite based on movement direction (adjust based on your sprite's default orientation)
        if (moveInput > 0) // Moving right
        {
            sr.flipX = false;
        }
        else if (moveInput < 0) // Moving left
        {
            sr.flipX = true;
        }
    }
}