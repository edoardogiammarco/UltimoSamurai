using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class BaseEnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private Vector3 localScale;
    public int maxHealt = 100;
    int currentHealth;
    public Animator animator;
    public GameObject enemy;
    public GameObject playerGameObject;
    // attack variables
    public Transform enemyAttackPoint;
    public float attackrange=1;
    public int attackDamage= 20;
    public LayerMask actorLayers;
    public bool nowAttack;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform target;                        //AIPathfinder
    Path path;                                      //AIPathfinder
    public float nextWaypointDistance = 1f;         //AIPathfinder
    int currentWaypoint = 0;                        //AIPathfinder
    bool reachedEndOfPath = false;                  //AIPathfinder
    Seeker seeker;                                  //AIPathfinder

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();            //AIPathfinder
        rb = GetComponent<Rigidbody2D>();           //AIPathfinder
        InvokeRepeating("UpdatePath", 0f, .5f);     //AIPathfinder
        
        //rb = GetComponent<Rigidbody2D>();
        //player = FindObjectOfType(typeof(Player)) as Player;
        moveSpeed = 200f;
        localScale = transform.localScale;
        currentHealth = maxHealt;
        animator.SetBool("isAlive",true);
        
    }

    /*AIPathfinder Methods*/
    void UpdatePath() {
        if (seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate() {



        //check if the enemy is near the player and attack
        if(timeBtwAttack<=0)  Attack();
        else timeBtwAttack-= Time.deltaTime;
        
        
        //check if the enemy is moving
        if(rb.velocity.x!= 0 || rb.velocity.y!=0)         animator.SetFloat("speed",1f);


        /*START OF AI PATHFINDER SCRIPT*/
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * moveSpeed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }
        /*END OF AI PATHFINDER SCRIPT*/


       
       
        /*Change sprite direction*/
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
        //move enemy away from the player
        

        //play hurt animation
        animator.SetTrigger("hit");

        if( currentHealth <= 0 ){
            //play death animation;
            Die();
        }
    }
    void Die(){
        
        //  death animation
        animator.SetBool("isAlive",false);
        animator.SetTrigger("isDead");
        GetComponent<Collider2D>().enabled=false;
        /* Destroying enemy ninja*/
        GameObject.Destroy(enemy,2f);
      
    }
    void Attack(){
        if( ((target.transform.position.x-enemy.transform.position.x<= 1) 
             && ( target.transform.position.x - enemy.transform.position.x>= -1))
                                             &&
                    ((target.transform.position.y-enemy.transform.position.y<= 1) 
                       && ( target.transform.position.y - enemy.transform.position.y>= -1)) )
             
                       
                 {
                    timeBtwAttack= startTimeBtwAttack;
                    // start attack animation
                    animator.SetTrigger("attack");
                    //transform.GetComponent<KnockBackScript>().PlayFeedback(playerGameObject);
                    // Detect player in range of attack
                    Collider2D[] hitplayer = Physics2D.OverlapCircleAll(enemyAttackPoint.position,attackrange,actorLayers);

                     /*Damage enemies*/  
                    foreach ( Collider2D player in hitplayer){
                    player.GetComponent<PlayerCombat>().PlayerTakeDamage(attackDamage);
                    }

                 }


    }
    void OnDrawGizmosSelected(){
        if ( enemyAttackPoint == null) return;
        Gizmos.DrawWireSphere(enemyAttackPoint.position,attackrange);
        
 
    }
}
