using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
  


    // Start is called before the first frame update
    
    void Start(){

        Destroy(gameObject,5f);      // destroy kunai after 5 seconds of spawn 
    }



    void OnTriggerEnter2D(Collider2D enemyCollider){

        if(enemyCollider.tag == "enemy"){    // is kunai hitting an enemy ?
            enemyCollider.GetComponent<BaseEnemyScript>().TakeDamage(10); // decrease enemy current health
        }

    }


}
