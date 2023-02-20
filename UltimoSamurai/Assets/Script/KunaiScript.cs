using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
    /* 
        Start method is called every time a new kunai is created.
        It destroys the kunai 5 seconds after it being launched (created).
    */
    void Start()
    {
        Destroy(gameObject,5f);     
    }

    /*
        This method is called when the kunai collides another game object that has a 2D collider.
        If it collides, it will apply the damage to the target by calling the 'TakeDamage' method
    */
    void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        if(enemyCollider.tag == "enemy")
        {
            enemyCollider.GetComponent<BaseEnemyScript>().TakeDamage(10);
        }
    }
}
