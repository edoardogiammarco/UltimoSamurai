using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class BaseEnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private Vector3 directionToPlayer;              //vector updates to get direction to player
    private Vector3 localScale;
    //public Player player;
    public int maxHealt = 100;
    int currentHealth;
    public Animator animator;
    public GameObject enemy ;

    public Transform target;                        //AIPathfinder
    Path path;                                      //AIPathfinder
    public float nextWaypointDistance = 3f;         //AIPathfinder
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
        animator.SetFloat("speed",1f);
    }

    //AIPathfinder
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

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y,0);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, 0);
        }
    }
    /*
    private void FixedUpdate()
    {
        if ( currentHealth<=0){
            rb.velocity = new Vector2(transform.position.x,transform.position.y);
        }
         MoveEnemy();
    }

    private void MoveEnemy(){
        
        directionToPlayer = (target.transform.position - transform.position).normalized;
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
    */
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
        animator.SetTrigger("isDead");
        GetComponent<Collider2D>().enabled=false;
        /* Destroying enemy ninja*/
        GameObject.Destroy(enemy,2f);
      
    }
    void Attack(){
        

    }
}
