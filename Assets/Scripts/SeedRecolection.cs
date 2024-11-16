using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SeedRecolection : MonoBehaviour
{

    public int currentSeed;
    public int maxSeed = 3;
    
    public GameObject fin;


    
    
    // Start is called before the first frame update
    void Start()
    {
        currentSeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSeed == 3) 
        {
            fin.SetActive(true);
        }
    }


    private void CollectedSeeds()
     {
        if (currentSeed <= 3)
        {
            currentSeed++;
            Debug.Log("Tenes una nueva semilla");
        }
     }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))

        {Destroy(gameObject);}

        CollectedSeeds();
    }
}
