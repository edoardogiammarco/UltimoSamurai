using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {

 
    Destroy(gameObject,5f);     


        
    }



    void OnTriggerEnter2D(Collider2D enemyCollider){

        if(enemyCollider.tag == "enemy"){
            enemyCollider.GetComponent<BaseEnemyScript>().TakeDamage(50);
        }

    }


}
