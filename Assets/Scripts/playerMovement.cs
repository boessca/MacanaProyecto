using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class playerMovement : MonoBehaviour
{

[Header("Horizontal Movement")]
public bool isMooving = false;
public float speed = 5f;

[Header("JUmp")]

public float jumpForce =6f;
private bool isjumping;
public bool isGrounded;


[Header("Plant Attack and Grab Seeds")]
private bool isAttacking;
public int seeds = 0;
public LayerMask plantLayer;
public Transform plantCheck;
public LayerMask groundLayer;
public Transform groundCheck;


private Rigidbody2D _rb;
private Animator _animator;


   
    void Start()
    {
        //llama al rigidbody y al animator del personaje
       _rb = GetComponent <Rigidbody2D>();
       _animator = GetComponent<Animator>();
    }

   
    void Update()
    {
       Jump();
       hitPlant();
       Animator();
       HorizontalMovement();

    }

      private void HorizontalMovement()
      {
       float moveInput = Input.GetAxis("Horizontal");

       if(moveInput < 0.0f) 
       {
        transform.localScale = new Vector3(-1, 1, 1);
       }

       else if (moveInput > 0.0f) 
       {
        transform.localScale = new Vector3(1, 1, 1);
       }

       _rb.velocity = new Vector2(moveInput * speed, _rb.velocity.y);

      }

          private void Animator()
      {

        float moveInput = Input.GetAxis("Horizontal");

       _animator.SetBool("isWalking", moveInput != 0.0f);
       _animator.SetBool("isAttacking", isAttacking);
       _animator.SetBool("isGrounded",touchGround());

         float yvelocity;
         yvelocity = _rb.velocity.y;
         _animator.SetFloat("yvelocity", yvelocity);
       
      }

         public void Jump()
     {
        if (Input.GetKeyDown(KeyCode.Space) && touchGround())
        {
         _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         _animator.SetBool("isjumping", isjumping);

        }
    }

    public bool touchGround()
    {
     return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.4f, 0.6f), CapsuleDirection2D.Vertical, 0, groundLayer);
    }    

   
    public void hitPlant()
    {
       if (Input.GetKeyDown(KeyCode.X)) 
        {
            isattacking();
        }
    }

  
        public bool TouchingPlant()
    {
        return Physics2D.OverlapCapsule(plantCheck.position, new Vector2(10f, 10f), CapsuleDirection2D.Vertical, 0, plantLayer);
    }


    public void isattacking()
    {
        isAttacking = true;
    }

    public void noattacking()
    {
        isAttacking = false;
    }

    public void isJumping()
    {
        isjumping = true;
    }

    public void isnotJumping()
    {
        isjumping = false;
    }

     
    }


