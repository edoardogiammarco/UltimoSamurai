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


    /* Attack variables */ 
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

        // If time between the last attack is passed , attack , else wait for it
        if(timeBtwAttack<=0 )  Attack();
        else timeBtwAttack-= Time.deltaTime;

        if( currentHealth <= 0 ) enemy.transform.GetComponent<BaseEnemyMovement>().enabled= false; // stop seeking player when enemy is dead

    }



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

        // Death animation
        GetComponent<Collider2D>().enabled=false;

        animator.SetBool("isAlive",false);
        animator.SetTrigger("isDead");
        // Deactivate enemy movement
        GetComponent<BaseEnemyMovement>().enabled=false;
        // Update wave system kill count
        WaveSystem.GetComponent<WaveSystemScript>().EnemyKilled();
        Destroy(enemy,2.5f); // destroy sprite

    }

    
    void Attack(){
        // if I'm near to the player  , Attack!
        startTimeBtwAttack= Random.Range(1.0f,3.0f);
        probabilityOfAttack = Random.Range(0,10);
        if( ((target.transform.position.x-enemy.transform.position.x<= 1.5f) 
             && ( target.transform.position.x - enemy.transform.position.x>= -1.5f))
                                             &&
                    ((target.transform.position.y-enemy.transform.position.y<= 1.5f) 
                       && ( target.transform.position.y - enemy.transform.position.y>= -1.5f))
                            && probabilityOfAttack<=7 )
                 {
                    timeBtwAttack = startTimeBtwAttack;
                    // start attack animation
                    animator.SetTrigger("attack");
                    //transform.GetComponent<KnockBackScript>().PlayFeedback(playerGameObject);
                 }
        else timeBtwAttack=0.5f; 

    }
    

    public void AttackAfterAnimation(){

                    // Detect player in range of attack
                    Collider2D[] hitplayer = Physics2D.OverlapCircleAll(enemyAttackPoint.position,attackrange,actorLayers);

                     /*Damage enemies*/  
                    foreach ( Collider2D player in hitplayer){
                        player.GetComponent<PlayerCombat>().PlayerTakeDamage(attackDamage);
                    }

    }

    // draws the sphere of enemy attack point // 
    void OnDrawGizmosSelected(){

        if ( enemyAttackPoint == null) return;
        Gizmos.DrawWireSphere(enemyAttackPoint.position,attackrange);
        
    }

    
    void startKnockBack(){

        transform.GetComponent<KnockBackScript>().PlayFeedback(playerGameObject);
    
    }


    /* drop a coin with a certain probability when enemy dies*/
    public void DropCoin(){

        int dropCoin = Random.Range(0,10);
        if(dropCoin<=5+playerGameObject.GetComponent<Player>().GetLuck()){
            Instantiate(CoinGameObject,transform.position, Quaternion.identity);
        }

    } 


    /***********Sound Methods************/
    
    public void PlayPoofSound(){

        PoofSound.Play();
    }
    public void PlayAttackSound(){
        attackSound.Play();
    }

}
