using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class playerMovement : MonoBehaviour
{
public bool isGrounded;
public bool isMooving = false;
public float speed = 5f;
public float jumpForce =6f;

public LayerMask plantLayer;
public Transform plantCheck;

public LayerMask groundLayer;
public Transform groundCheck;


public int lives = 3; 
public int seeds = 0;

private bool isAttacking;

private Rigidbody2D _rb;
private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
       _rb = GetComponent <Rigidbody2D>();
       _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       float moveInput = Input.GetAxis("Horizontal");

       if(moveInput < 0.0f) transform.localScale = new Vector3(-1, 1, 1);
       else if (moveInput > 0.0f) transform.localScale = new Vector3(1, 1, 1);

       _rb.velocity = new Vector2(moveInput * speed, _rb.velocity.y);

       _animator.SetBool("isWalking", moveInput != 0.0f);
       _animator.SetBool("isAttacking", isAttacking);
       
       Jump();
       hitPlant();

    }
     public void Jump()
     {
        if (Input.GetKeyDown(KeyCode.Space) && touchGround())
        {
         _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

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

        //overlap crea capsula imaginaria / plantcheck desde la posicion de la planta / si toca la capa de planta te devuelve que si, sino que no
    {
        return Physics2D.OverlapCapsule(plantCheck.position, new Vector2(8f, 8f), CapsuleDirection2D.Vertical, 0, plantLayer);
    }



    public void isattacking()
    {
        isAttacking = true;
    }

    public void noattacking()
    {
        isAttacking = false;
    }

    public void ReceiveSeed()
{
    seeds++; // Aumenta el contador de semillas
    lives--; // Pierde una vida al recibir la semilla
    Debug.Log("Recibiste una semilla y perdiste una vida. Vidas restantes: " + lives);
}

public void PlantSeed()
{
    if (seeds > 0)
    {
        seeds--; // Disminuye el contador de semillas
        lives++; // Recupera una vida al plantar la semilla
        Debug.Log("Plantaste una semilla y recuperaste una vida. Vidas restantes: " + lives);
    }
}
  

    }


