using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Animator animator;
    public bool isAttacking = false;

    // Update is called once per frame
   public void Update()
    {

        isAttacking = AnimatorIsPlaying();
        if( Input.GetButtonDown("Attack1Button")) {
            Attack1();
        }
    
        if( Input.GetButtonDown("Attack2Button")) {
            Attack2();
        }    
        
    }

    public void Attack1() {

        if (!isAttacking)animator.SetTrigger("Attack1");

    }

    public void Attack2() {

        if(!isAttacking)    animator.SetTrigger("Attack2");        

    }

    // Checks if player is currently attacking
    bool AnimatorIsPlaying() {

        return AnimatorIsPlaying()
                && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") 
                && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2");
    
    }
 




}
