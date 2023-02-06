using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class BaseEnemyScript : MonoBehaviour
{
    
    public Transform target; 
    public int maxHealt = 100;
    int currentHealth;
    public Animator animator;
    public GameObject enemy;
    public GameObject playerGameObject;
    public GameObject CoinGameObject;
    public GameObject WaveSystem;
    public AudioSource PoofSound;
    public AudioSource attackSound;


    // attack variables
    public Transform enemyAttackPoint;
    public float attackrange=1;
    public int attackDamage= 20;
    public LayerMask actorLayers;
    public bool nowAttack;
    private float timeBtwAttack;
    private float startTimeBtwAttack;
    private int probabilityOfAttack;

    // Start is called before the first frame update
    void Start(){
    
        currentHealth = maxHealt;
        animator.SetBool("isAlive",true);
        
    }

    void FixedUpdate() {

        //check if the enemy is near the player and attack
        if(timeBtwAttack<=0 )  Attack();
        else timeBtwAttack-= Time.deltaTime;

        //if( canAttack()) Attack();
        //else timeBtwAttack -= Time.deltaTime;

        if( currentHealth <= 0 ) enemy.transform.GetComponent<BaseEnemyMovement>().enabled= false;

    }

    /*
    private bool canAttack() {

        startTimeBtwAttack= Random.Range(2.0f,4.0f);
        probabilityOfAttack = Random.Range(0,10);

        // If enemy in range of player        
        if((((target.transform.position.x-enemy.transform.position.x<= 1) 
             && (target.transform.position.x - enemy.transform.position.x>= -1))
                                             &&
                    ((target.transform.position.y-enemy.transform.position.y<= 1) 
                       && (target.transform.position.y - enemy.transform.position.y>= -1))
                            && probabilityOfAttack<=7)
                            && timeBtwAttack <= 0)
                            {
                                return true;
                            }
        return false;

    }
    */

    public void TakeDamage(int damage){

        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("hit");
        // knockback
        
        if( currentHealth <= 0 ){
            //play death animation;
            enemy.transform.GetComponent<BaseEnemyMovement>().enabled= false;
            Die();
        }

    }

    void Die(){

        // Decrease player's darkness
        playerGameObject.GetComponent<Player>().decreaseDarkness();

        // Death animation
        GetComponent<Collider2D>().enabled=false;

        animator.SetBool("isAlive",false);
        animator.SetTrigger("isDead");
        GetComponent<BaseEnemyMovement>().enabled=false;

        WaveSystem.GetComponent<WaveSystemScript>().EnemyKilled();
        Destroy(enemy,2.5f);
        //Vector2 deathPosition = transform.position;

    }
/*
    void Attack() {
        
        timeBtwAttack = startTimeBtwAttack;
        // Start attack animation
        animator.SetTrigger("attack");

    }
*/
    
    void Attack(){
// sostituire attacco
        startTimeBtwAttack= Random.Range(2.0f,4.0f);
        probabilityOfAttack = Random.Range(0,10);
        if( ((target.transform.position.x-enemy.transform.position.x<= 1) 
             && ( target.transform.position.x - enemy.transform.position.x>= -1))
                                             &&
                    ((target.transform.position.y-enemy.transform.position.y<= 1) 
                       && ( target.transform.position.y - enemy.transform.position.y>= -1))
                            && probabilityOfAttack<=7 )
                 {
                    Debug.Log("Entro nell'if dell'attacco");
                    timeBtwAttack = startTimeBtwAttack;
                    // start attack animation
                    animator.SetTrigger("attack");
                    //transform.GetComponent<KnockBackScript>().PlayFeedback(playerGameObject);
                 }

    }
    

    public void AttackAfterAnimation(){

                    // Detect player in range of attack
                    Collider2D[] hitplayer = Physics2D.OverlapCircleAll(enemyAttackPoint.position,attackrange,actorLayers);

                     /*Damage enemies*/  
                    foreach ( Collider2D player in hitplayer){
                        player.GetComponent<PlayerCombat>().PlayerTakeDamage(attackDamage);
                    }

    }

    void OnDrawGizmosSelected(){

        if ( enemyAttackPoint == null) return;
        Gizmos.DrawWireSphere(enemyAttackPoint.position,attackrange);
        
    }

    void startKnockBack(){

        transform.GetComponent<KnockBackScript>().PlayFeedback(playerGameObject);
    
    }

    public void DropCoin(){

        int dropCoin = Random.Range(0,10);
        if(dropCoin<=5+playerGameObject.GetComponent<Player>().GetLuck()){
            Instantiate(CoinGameObject,transform.position, Quaternion.identity);//parametri: game object da instanziare; posizione ; rotazione 
        }

    } 

    public void PlayPoofSound(){

        PoofSound.Play();
    }
    public void PlayAttackSound(){
        attackSound.Play();
    }

}
