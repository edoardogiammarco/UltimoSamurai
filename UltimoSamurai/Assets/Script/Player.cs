using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private int currHealth;
    private int maxHealth = 20;
    public Animator animator;

    // Start is called before the first frame update
    private void Start(){
        boxCollider = GetComponent<BoxCollider2D>();    
        currHealth= maxHealth;
    }

    // Update is called once per frame
    private void FixedUpdate(){
        // Reset MoveDelta
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
    }

    public void takeHit(int damage){
        currHealth -= damage;
        animator.SetTrigger("isHurt");
        if(currHealth<=0){
            die();
        }

    }
    void die(){
        animator.SetBool("isDead",true);

    

    }


    
}
