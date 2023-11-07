using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 15f;
    private float jumpForce = 40f;
    private bool isFacingLeft = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;  
    [SerializeField] private Animator animator;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if(Input.GetKey("space") && isGrounded())
        {
            Debug.Log("Space Pressed");
            rb.velocity= new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetKey("space") && rb.velocity.y > 0f)
        {
            rb.velocity= new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if(Input.GetKey("up"))
        {
            animator.SetBool("LookingUp", true);
        } else
        {
            animator.SetBool("LookingUp", false);
        }

        if(Input.GetKey("down"))
        {
            animator.SetBool("LookingDown", true);
        } else
        {
            animator.SetBool("LookingDown", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingLeft && horizontal > 0f || !isFacingLeft && horizontal < 0f)
            {
                isFacingLeft = !isFacingLeft;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            
        }

    }
}
