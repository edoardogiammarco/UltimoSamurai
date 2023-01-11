using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Animator animator;
    public LayerMask enemyLayers;
    public bool isAttacking = false;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public float attackrange1 = 0.5f;
    public float attackrange2 = 1f;
    public int attackDamage1 = 20;
    public int attackDamage2 = 40;
    public float attackRate1 = 2f;
    float nextAttackTime1 = 0f;

    // Update is called once per frame
   public void Update()
    {        
    }

    public void OnClickAttack1() {
        if(Time.time>= nextAttackTime1){

        
        Attack1();
        nextAttackTime1 = Time.time + 1f/ attackRate1;
        }

    }
        public void Attack1() {
        
        
        /* Animation starts*/
        isAttacking = AnimatorIsPlaying();
        if (!isAttacking)animator.SetTrigger("Attack1");

        /*Detect enemies in range of attack*/
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint1.position,attackrange1,enemyLayers);

        /*Damage enemies*/
        foreach ( Collider2D enemy in hitEnemies){
            enemy.GetComponent<BaseEnemyScript>().TakeDamage(attackDamage1);
        }
    }

    public void Attack2() {
        isAttacking = AnimatorIsPlaying();
        if(!isAttacking)    animator.SetTrigger("Attack2");        

        /*Detect enemies in range of attack*/
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint1.position,attackrange1,enemyLayers);

        /*Damage enemies*/
        foreach ( Collider2D enemy in hitEnemies){
            enemy.GetComponent<BaseEnemyScript>().TakeDamage(attackDamage2);
        }
    }

    // Checks if player is currently attacking
    bool AnimatorIsPlaying() {

        return   animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") 
                || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2");
    
    }


    /* Function that draws the attackPoint */
    void OnDrawGizmosSelected(){
        if ( attackPoint1 == null) return;
        if ( attackPoint2 == null) return;
        Gizmos.DrawWireSphere(attackPoint1.position,attackrange1);
        Gizmos.DrawWireSphere(attackPoint2.position,attackrange2);
 
    }
 




}
