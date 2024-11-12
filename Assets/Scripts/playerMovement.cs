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
public int lives = 3; 
public int seeds = 0;


private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
       _rb = GetComponent <Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
       float moveInput = Input.GetAxis("Horizontal");
       _rb.velocity = new Vector2(moveInput * speed, _rb.velocity.y);

       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
         _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }
    
          private void OnCollisionEnter2D(Collision2D collision)
    {
        // me dice si el objeto con el que choca esta en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            // isGrounded me dice si esta en el suelo
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // cambia isGrounded a falso cuando el personaje deja de tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }

    public void hitPlant()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
        }
    }

  
        public bool TouchingPlant()

        //overlap crea capsula imaginaria / plantcheck desde la posicion de la planta / si toca la capa de planta te devuelve que si, sino que no
    {
        return Physics2D.OverlapCapsule(plantCheck.position, new Vector2(2f, 0.6f), CapsuleDirection2D.Vertical, 0, plantLayer);
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


