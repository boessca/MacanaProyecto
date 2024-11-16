using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlant : MonoBehaviour

{
    public float Health = 3;
    private int hits = 0; 
    public playerMovement player; 
    public GameObject seed;  
    Animator _animator;

    public GameObject seedPrefab;

      
    
    void Start()
    {
        if (player == null) 
        {
            player = FindObjectOfType<playerMovement>(); 
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
           Debug.Log("cortaste la planta");
        }
        
    } 

 
  
    public void Defeat()
    {
     seed.SetActive(true);
     Destroy(gameObject);
    }   


  void OnTriggerStay2D(Collider2D other)
    {
                         
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.X))
        {
            hits++;
            Debug.Log("Golpes a la planta: " + hits);    
    
            if (hits >= 3)
            {
               Defeat();               
            }

        }

    }


}





 

   