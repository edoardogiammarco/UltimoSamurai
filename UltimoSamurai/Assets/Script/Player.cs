using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public GameObject playerGameObject;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private int currHealth;
    private int maxHealth = 100;
    public Animator animator;
    public int darkness; 

    // Start is called before the first frame update
    private void Start(){
        boxCollider = GetComponent<BoxCollider2D>();    
        currHealth= maxHealth;
        animator.SetBool("isAlive",true);
        darkness = 0; 

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
    public void die(){
        animator.SetBool("isAlive",false);
        animator.SetTrigger("death");
        GetComponent<MovePlayer>().enabled = false;

        Debug.Log("Il giocatore è morto ");
    }

    public void incrementDarkness(){
        darkness+= 40;
    }


    
}
