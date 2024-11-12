using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlant : MonoBehaviour

{
   public int Health = 3;
    private int hits = 0; // Contador de golpes recibidos
    public playerMovement player; // Referencia al jugador para otorgarle la semilla
    public GameObject newSeedPrefab;   

  

    
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<playerMovement>(); // Encuentra el objeto del jugador en la escena
        }
    }

    
    void Update()

    {
      

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
         // Pone la semilla en el lugar de EvilPlant
    Instantiate(newSeedPrefab, transform.position, Quaternion.identity);

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
                player.ReceiveSeed(); // Otorga una semilla al jugador
                Destroy(gameObject); // Destruye la planta después de 3 golpes
            
                 
            }

            
        }


    }
}





 

   