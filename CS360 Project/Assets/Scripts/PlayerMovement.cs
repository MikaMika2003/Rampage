using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is used to control the main character's movements
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


    // On start it gets the character and places it within the scene
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // This used to determine and update the current  movement of the player 
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Checks if the up key is pressed 
        if(Input.GetKey("up"))
        {
            animator.SetBool("LookingUp", true);
        } else
        {
            animator.SetBool("LookingUp", false);
        }

        // Checks if the down key is pressed
        if(Input.GetKey("down"))
        {
            animator.SetBool("LookingDown", true);
        } else
        {
            animator.SetBool("LookingDown", false);
        }

        // Checks if the z key is pressed
        if(Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("IsPunching", true);
            StartCoroutine(WaitSecond());
            animator.SetBool("IsPunching", false);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        Jumping();
    }

    // Introduces a wait period for character movement
    IEnumerator WaitSecond(){
        yield return new WaitForSeconds(1);
    }

    // Checks if the space button is pressed 
    private void Jumping()
    {
        animator.SetBool("IsJumping", !isGrounded()); 

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpForce);
            
        }
    }


    // Keeps the character grounded to the added platform 
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    } 

    // Checks the direction in which the character is facing
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
