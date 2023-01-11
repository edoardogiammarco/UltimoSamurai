using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyScript : MonoBehaviour
{

    public int maxHealt = 100;
    int currentHealth;
    public Animator animator;
    public GameObject enemy ;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealt;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        //play hurt animation

        if( currentHealth <= 0 ){
            //play death animation;
            Die();
        }
    }
    void Die(){

        //  death animation
        
        animator.SetTrigger("isDead");

        /* Destroying enemy ninja*/
        GetComponent<Collider2D>().enabled=false;
        this.enabled = false;
        GameObject.Destroy(enemy,2f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
