using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public LayerMask enemyLayers;
    public GameObject attac2Image;
    public bool isAttacking = false;
    public int attackDamage1 = 20;
    public int attackDamage2 = 40;
    
    //Audio Source
    public AudioSource takeHitSound;
    public AudioSource attack1Sound;
    public AudioSource attack2Sound;
    public AudioSource attackCritSound;
    
    // manage attack flow
    private float timeBtwAttack1;      
    public float startTimeBtwAttack1;
    private float timeBtwAttack2;      
    public float startTimeBtwAttack2;
    public bool nowAttack1;
    public bool nowAttack2;

    //shop variables
    public int criticalHit;
    public int currStrength;
    public int currCriticalHitProbability;

    // attack point for  OverLapAreaAll
    public Transform attack1RectangleCorner;
    public Transform attack1RectangleOppositeCorner;
    public Transform attack1CriticalRectangleCorner;
    public Transform attack1CriticalRectangleOppositeCorner;
    public Transform attack2RectangleCorner;
    public Transform attack2RectangleOppositeCorner;    

    // Start is called before the first frame update
    void Start(){
        currStrength=0;
        currCriticalHitProbability=5;
   
    } 

   // Update is called once per frame
   public void Update(){       
     
        if(timeBtwAttack1<=0) nowAttack1=true;
        else timeBtwAttack1-= Time.deltaTime;
      

        if(timeBtwAttack2<=0){
            nowAttack2=true;
            attac2Image.SetActive(true);
        }
        else timeBtwAttack2-= Time.deltaTime;
      
    }
    

    /************Attack1 Methods************/ 
  
    public void OnAttack1(InputAction.CallbackContext ctd1){

        if(nowAttack1== true){        
             Attack1();
             timeBtwAttack1= startTimeBtwAttack1;
            }
        nowAttack1= false;
        
    }   
    void Attack1() { 
        criticalHit = AssignCriticalMultiplier();
        if(criticalHit == 4  ) animator.SetTrigger("Attack1Critical");
        else animator.SetTrigger("Attack1");
     
        
    
    }
    public void Attack1DuringAnimation(){

             /*Detect enemies in range of attack*/
             Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(attack1RectangleCorner.position,attack1RectangleOppositeCorner.position,enemyLayers);
             attack1Sound.Play();
             
             /*Damage enemies*/  
             foreach ( Collider2D enemy in hitEnemies){
                 enemy.GetComponent<BaseEnemyScript>().TakeDamage((attackDamage1+currStrength)*criticalHit);
                }

    }
    public void Attack1CriticalDuringAnimation(){
             /* Decrease darkness */
             gameObject.GetComponent<Player>().decreaseDarkness();

             /*Detect enemies in range of attack*/
             Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(attack1CriticalRectangleCorner.position,attack1CriticalRectangleOppositeCorner.position,enemyLayers);
             attackCritSound.Play();// play crit hit sound
             
             /*Damage enemies*/  
             foreach ( Collider2D enemy in hitEnemies){
                 enemy.GetComponent<BaseEnemyScript>().TakeDamage((attackDamage1+currStrength)*criticalHit);
                }

    }    

 
    /************Attack2 Methods************/    

    public void OnAttack2(InputAction.CallbackContext ctd2){

        if(nowAttack2== true){        
             Attack2();
             attac2Image.SetActive(false);
             timeBtwAttack2= startTimeBtwAttack2;
            }
        nowAttack2= false;
        
    }

    public void Attack2() {
             
             animator.SetTrigger("Attack2");
             transform.GetComponent<Player>().incrementDarkness();
             if(transform.GetComponent<Player>().currDarkness>=100) {
                transform.GetComponent<Player>().Die();
             }

    }

    public void Attack2DuringAnimation(){
             /*Detect enemies in range of attack*/
             Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(attack2RectangleCorner.position,attack2RectangleOppositeCorner.position,enemyLayers);
             attack2Sound.Play();
             /*Is that a critical hit*/
             criticalHit= AssignCriticalMultiplier();
             /*Damage enemies*/  
             foreach ( Collider2D enemy in hitEnemies){
                 enemy.GetComponent<BaseEnemyScript>().TakeDamage((attackDamage2+currStrength)*criticalHit);
                }

    }
            


    public int AssignCriticalMultiplier(){

        int criticalPercentage = Random.Range(0,100);
        if ( criticalPercentage<currCriticalHitProbability){ // if im in the range for a critical hit 
            return 4; // return the critical hit multiplier
        }
        else { // if im not in the range for  a critical hit 
            return 1; // critical hit multiplier is useless, has no effect on the damage
        }

    }



    public void PlayerTakeDamage ( int damage){

        transform.GetComponent<Player>().takeHit(damage);
        takeHitSound.Play();

    }

    void goToGameOverScene(){ 
        SceneManager.LoadScene("Game Over"); 
    }


   
   
    /************Power_Up Methods************/


    public void AddCriticalHitProbability(){ currCriticalHitProbability += 2; }     // Increase of a 2% critical hit probability 

    
    public void AddStrength(){ currStrength += 5; } // Increase both attack1 and attack2

    public int getCriticalHitProbability() { return currCriticalHitProbability; }

    public int getAttackBonus(){ return currStrength; }


} 
