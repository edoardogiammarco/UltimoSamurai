using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaseEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    public Transform target;                        //AIPathfinder
    Path path;                                      //AIPathfinder
    public float nextWaypointDistance = 1f;         //AIPathfinder
    int currentWaypoint = 0;                        //AIPathfinder
    bool reachedEndOfPath = false;                  //AIPathfinder
    Seeker seeker;                                  //AIPathfinder
    private Vector3 localScale;
    public Animator animator;
    // Start is called before the first frame update
    
    void Start(){
        
        seeker = GetComponent<Seeker>();            //AIPathfinder
        rb = GetComponent<Rigidbody2D>();           //AIPathfinder
        InvokeRepeating("UpdatePath", 0f, .5f);     //AIPathfinder
        
        //player = FindObjectOfType(typeof(Player)) as Player;
        moveSpeed = 360f;
        localScale = transform.localScale;
        
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
    // Update is called once per frame
    void Update()
    {
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

        //check if the enemy is moving
        if(rb.velocity.x!= 0 || rb.velocity.y!=0)         animator.SetFloat("speed",1f);
       
       
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
}
