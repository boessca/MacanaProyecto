using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlant : MonoBehaviour

{
   public float Health = 3;
    private int hits = 0; // Contador de golpes recibidos
    public playerMovement player; // Referencia al jugador para otorgarle la semilla
    public GameObject seed;  
    Animator _animator;

    
  

  

    
    void Start()
    {
        if (player == null) // null es que no tiene valor. entonces que no referencia a ningun objeto
        {
            player = FindObjectOfType<playerMovement>(); // Encuentra el objeto del jugador en la escena
        }

        _animator = GetComponent<Animator>();
    }

    
    void Update()

    {
      _animator.SetFloat("New Float" , hits);     

    }

    public void TakeDamage()
    {

      if (Health > 0)
        {
            Health--;

        }    
           
      if (Health <= 0)
        {
           Defeat();
           Debug.Log("Conseguiste una semilla");
        }
        
    } 

  

    public void Defeat()
    {
   
    seed.SetActive(true);

    // Elimina a EvilPlant del juego. Destroy es algo de unity que es para eliminar un objeto de la escena. No vuelve.
    Destroy(gameObject);
  
    }   



  void OnTriggerStay2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es el jugador y si presiona la tecla "X"
                 
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.X))
        {
            hits++;
            Debug.Log("Golpe a la planta: " + hits);
                
            

            if (hits >= 3)
            {
               Defeat();           
                 
            }

        }

    }

}





 

   