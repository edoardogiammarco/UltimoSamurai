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
    public AudioSource coinTaken;
    public AudioSource runningSound;
    public AudioSource takeHitSound;
    private int currCoin;
    public int Luck;

    // Start is called before the first frame update
    private void Start(){
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
        animator.SetBool("isAlive",false);
        animator.SetTrigger("death");
        GetComponent<MovePlayer>().enabled = false;

        Debug.Log("Il giocatore è morto ");
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
