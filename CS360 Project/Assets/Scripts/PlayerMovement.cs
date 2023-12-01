using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 15f;
    public float jumpForce = 30f;
    private bool isFacingLeft = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;  
    [SerializeField] private Animator animator;



    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Code to Look Up
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

        // Code for punching
        if(Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("IsPunching", true);
            StartCoroutine(WaitSecond());
            animator.SetBool("IsPunching", false);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        Jumping();
    }

    IEnumerator WaitSecond(){
        yield return new WaitForSeconds(1);
    }
    
    // Jump Code
    private void Jumping()
    {
        animator.SetBool("IsJumping", !isGrounded()); 

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpForce);
            
        }
    }


    // Detects ground
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    } 

    // Flips the character
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
