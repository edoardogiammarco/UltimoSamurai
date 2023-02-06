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
    public int maxHealth;
    public Animator animator;
    public int startDarkness= 0;
    public int currDarkness;
    public GameObject healthBar;
    public GameObject darknessBar;
    /* disaccorpare tutti gli audio*/ 
    public AudioSource coinTaken;
    public AudioSource runningSound;
    public AudioSource takeHitSound;
    public AudioSource deathSound;
    private int currCoin;
    public int Luck;
    public bool isPlayerAlive;

    // Start is called before the first frame update
    private void Start(){
        isPlayerAlive = true;
        maxHealth= 100;
        boxCollider = GetComponent<BoxCollider2D>();    
        currHealth= maxHealth;
        currCoin=0;
        currDarkness = startDarkness; 
        healthBar.GetComponent<HealthBarScript>().SetMaxHealth(maxHealth);
        darknessBar.GetComponent<HealthBarScript>().SetMaxDarkness(startDarkness);
        animator.SetBool("isAlive",true);
        Luck = 0;

    }

    // Update is called once per frame
    private void FixedUpdate(){
        // Reset MoveDelta
        moveDelta = Vector3.zero;
        float x = Input.GetAxisRaw("Horizontal");
    }

    public void takeHit(int damage){
        currHealth -= damage;
        healthBar.GetComponent<HealthBarScript>().SetHealth(currHealth);
        animator.SetTrigger("isHurt");
        if(currHealth<=0){
            die();
        }

    }
    public void die(){
        isPlayerAlive = false;
        animator.SetBool("isAlive",false);
        animator.SetTrigger("death");
        GetComponent<MovePlayer>().enabled = false;
        deathSound.Play();
    }

    public void incrementDarkness(){
        currDarkness+= 10;
        darknessBar.GetComponent<HealthBarScript>().SetDarkness(currDarkness);
    }

    public void CoinCollected(){
        coinTaken.Play();
        currCoin = currCoin +1 ;
        playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(currCoin);

    }

    public void decreaseDarkness() {

        int darknessToDecrease = 0;

        if(currDarkness >=10) {
            int value1 = 5;
            int value2 = 10;
            // Picking random to decrease from 5 - 10 every time an enemy is killed
            darknessToDecrease = Random.value < 0.5f ? value1 : value2;
        }
        else if (currDarkness == 5) {
            darknessToDecrease = 5;
        }
        else if (currDarkness == 0) { return; }

        currDarkness -= darknessToDecrease;
        darknessBar.GetComponent<HealthBarScript>().SetDarkness(currDarkness);
    }


    public int getCurrentCoin(){
        return currCoin;
    }
    public void SetCurrentCoin(int actualCoin){
        currCoin = actualCoin;
    }

    public void SetMaxHealth(int newMaxHealth){
        maxHealth = newMaxHealth;
    }
    public int CurrentMaxHealth(){
        return maxHealth;
    }

    public void setLuck(){
        Luck += 1;
    }
    public int GetLuck(){
        return Luck;
    }

    public void PlayRunningSound () {
        if(!runningSound.isPlaying){
             runningSound.Play();
        }
    }
    public void PauseRunningSound () {
        runningSound.Pause();
    }

    public void TakeHitSound(){
     //   takeHitSound.Play();
    }
    
}
