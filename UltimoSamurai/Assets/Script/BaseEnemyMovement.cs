using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaseEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 localScale;
    public Animator animator;
    public Seeker seeker;                           //AIPathfinder
    public Path path;                               //AIPathfinder
    public Transform target;                        //AIPathfinder
    
    private float moveSpeed;
    public float nextWaypointDistance = 1f;         //AIPathfinder
    private int currentWaypoint = 0;                //AIPathfinder
    private bool reachedEndOfPath = false;          //AIPathfinder
    
    // Start is called before the first frame update
    void Start(){
        
        seeker = GetComponent<Seeker>();            //AIPathfinder
        rb = GetComponent<Rigidbody2D>();           //AIPathfinder
        InvokeRepeating("UpdatePath", 0f, .5f);     //AIPathfinder
        
        moveSpeed = 500f;
        localScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Change sprite direction*/
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(localScale.x, localScale.y);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-localScale.x, localScale.y);
        }
        
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

}
