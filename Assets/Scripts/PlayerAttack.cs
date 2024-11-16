using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.X))
        {
            EvilPlant EvilPlant = collision.GetComponent<EvilPlant>();
            if (EvilPlant != null)
            {
                EvilPlant.TakeDamage();
            }
        }
    } 

 

}
