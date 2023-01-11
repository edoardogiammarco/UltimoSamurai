using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseEnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    public Player player;
    public int maxHealt = 100;
    int currentHealth;
    public Animator animator;
    public GameObject enemy ;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(Player)) as Player;
        moveSpeed = 2f;
        localScale = transform.localScale;
        currentHealth = maxHealt;
    }

    private void FixedUpdate()
    {
        if ( currentHealth<=0){
            rb.velocity= new Vector2(transform.position.x,transform.position.y);
         
        }
         MoveEnemy();
    }

    private void MoveEnemy()
    {

        
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
        
    }

    private void LateUpdate()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y,0);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, 0);
        }
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
        GetComponent<Collider2D>().enabled=false;
        /* Destroying enemy ninja*/
        GameObject.Destroy(enemy,2f);
      
    }
}
