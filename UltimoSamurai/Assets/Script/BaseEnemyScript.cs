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
    public int Luck;

    // attack variables
    public Transform enemyAttackPoint;
    public float attackrange=1;
    public int attackDamage= 20;
    public LayerMask actorLayers;
    public bool nowAttack;
    private float timeBtwAttack;
    private float startTimeBtwAttack;
    private int probabilityOfAttack;

    private WaveSystem waveSystem;

    // Start is called before the first frame update
    void Start(){
        
        Luck = 0;
        currentHealth = maxHealt;
        animator.SetBool("isAlive",true);
        
    }

   
    void FixedUpdate() {


        
        //check if the enemy is near the player and attack
        if(timeBtwAttack<=0 )  Attack();
        else timeBtwAttack-= Time.deltaTime;
        if( currentHealth <= 0 ) enemy.transform.GetComponent<BaseEnemyMovement>().enabled= false;



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
        //  death animation
        animator.SetBool("isAlive",false);
        animator.SetTrigger("isDead");
        GetComponent<BaseEnemyMovement>().enabled=false;
        Destroy(enemy,2.5f);
        Vector2 deathPosition = transform.position;
        //calls waveSystem function to update number of enemies in current wave
        waveSystem = waveSystem.getWaveSystem();
        waveSystem.OnEnemyDeath();

    }

    void Attack(){
    
        startTimeBtwAttack= Random.Range(2.0f,4.0f);
        probabilityOfAttack = Random.Range(0,10);
        if( ((target.transform.position.x-enemy.transform.position.x<= 1) 
             && ( target.transform.position.x - enemy.transform.position.x>= -1))
                                             &&
                    ((target.transform.position.y-enemy.transform.position.y<= 1) 
                       && ( target.transform.position.y - enemy.transform.position.y>= -1))
                            && probabilityOfAttack<=7 )
             
                 {
                    timeBtwAttack= startTimeBtwAttack;
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
        int dropCoin = Random.Range(0,9);
        if(dropCoin<=4+Luck){
            Instantiate(CoinGameObject,transform.position, Quaternion.identity);
        }
    } 

    public void setLuck(){
        Luck += 1;
    }

    public int GetLuck(){
        return Luck;
    }

}
