using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    
    // manage attack flow
    private float timeBtwAttack1;      
    public float startTimeBtwAttack1;
    public bool nowAttack1;
    private float timeBtwAttack2;      
    public float startTimeBtwAttack2;
    public bool nowAttack2;


    // Update is called once per frame
   public void Update()
    {        
        if(timeBtwAttack1<=0) nowAttack1=true;
        else timeBtwAttack1-= Time.deltaTime;
      

        if(timeBtwAttack2<=0) nowAttack2=true;
        else timeBtwAttack2-= Time.deltaTime;
      
    }
    
    public void OnAttack1(InputAction.CallbackContext ctd){
        if(nowAttack1== true){        
             Attack1();
             timeBtwAttack1= startTimeBtwAttack1;
            }
        nowAttack1= false;
        
    }

    public void OnAttack2(InputAction.CallbackContext ctd){
        if(nowAttack2== true){        
             Attack2();
             timeBtwAttack2= startTimeBtwAttack2;
            }
        nowAttack2= false;
        
    }
        
    void Attack1() {
      
        
             animator.SetTrigger("Attack1");

             /*Detect enemies in range of attack*/
             Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint1.position,attackrange1,enemyLayers);

             /*Damage enemies*/  
             foreach ( Collider2D enemy in hitEnemies){
                 enemy.GetComponent<BaseEnemyScript>().TakeDamage(attackDamage1);
                }
        
        
        

    }


    public void Attack2() {
     
        
             animator.SetTrigger("Attack2");

             /*Detect enemies in range of attack*/
             Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint2.position,attackrange2,enemyLayers);

             /*Damage enemies*/  
             foreach ( Collider2D enemy in hitEnemies){
                 enemy.GetComponent<BaseEnemyScript>().TakeDamage(attackDamage2);
                }
            


    }




    /* Function that draws the attackPoint */
    void OnDrawGizmosSelected(){
        if ( attackPoint1 == null) return;
        if ( attackPoint2 == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPoint1.position,new Vector3(2f, 2f, 1));
        Gizmos.DrawWireCube(attackPoint2.position,new Vector3(2, 1, 1));
 
    }

    public void TakeDamage ( int damage){
        animator.SetTrigger("isHurt");
    }
 




}
