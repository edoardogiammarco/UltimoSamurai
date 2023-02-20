using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /* Player game object */
    public GameObject playerGameObject;
    public Animator animator;
    private BoxCollider2D boxCollider;

    /* Player's game mechanics */
    public GameObject healthBar;
    public GameObject darknessBar;
    public GameObject waveSystem;
    private Vector3 moveDelta;
    public Leaderboard leaderboard;

    /* Audio Variables */
    public AudioSource coinTaken;
    public AudioSource runningSound;
    public AudioSource takeHitSound;
    public AudioSource deathSound;

    /* Player's variable fields */ 
    private int currHealth;
    public int maxHealth;
    public int startDarkness= 0;
    public int currDarkness;
    private int currCoin;
    public int Luck;
    public bool isPlayerAlive;
    
    /* Initializing player variable fields and enabling movement */
    // Start is called before the first frame update
    private void Start()
    {
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
    private void FixedUpdate()
    {
        // Reset MoveDelta
        moveDelta = Vector3.zero;
        float x = Input.GetAxisRaw("Horizontal");
    }

    public void takeHit(int damage)
    {
        currHealth -= damage;
        healthBar.GetComponent<HealthBarScript>().SetHealth(currHealth);
        animator.SetTrigger("isHurt");
        if(currHealth<=0){
            Die();
        }
    }

    public void Die()
    {
        int finalScore = waveSystem.GetComponent<WaveSystemScript>().GetTotalKills();
        StartCoroutine(SaveScoreRoutine(finalScore));
        isPlayerAlive = false;
        animator.SetBool("isAlive",false);   
        animator.SetTrigger("death");                               // set variables for animator
        GetComponent<MovePlayer>().enabled = false;                 // player cant move anymore...
        deathSound.Play();                                          // last breath....
    }

    private IEnumerator SaveScoreRoutine (  int score )
    {
        yield return leaderboard.SubmitScoreRoutine(score);

    }

    public void CoinCollected()
    {   // Update current coin and coin counter text
        coinTaken.Play();
        currCoin = currCoin +1 ;
        playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(currCoin);

    }

    public void incrementDarkness()
    {
        currDarkness+= 10;
        darknessBar.GetComponent<HealthBarScript>().SetDarkness(currDarkness);
    }

    /* Darkness is decreased every time a critical hit is performed by 5 or 10 points */
    public void decreaseDarkness()
    {
        int darknessToDecrease = 0;

        if(currDarkness >=10) {
            int value1 = 5;
            int value2 = 10;
            darknessToDecrease = Random.value < 0.5f ? value1 : value2;
        }
        else if (currDarkness == 5) {
            darknessToDecrease = 5;
        }
        else if (currDarkness == 0) { return; }

        currDarkness -= darknessToDecrease;
        darknessBar.GetComponent<HealthBarScript>().SetDarkness(currDarkness);
    }

    /************Shop and Coin Counter Methods ************/

    public int getCurrentCoin()
    {
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

    /************Sound Methods************/ 

    public void PlayRunningSound () {
        if(!runningSound.isPlaying){
             runningSound.Play();
        }
    }
    public void PauseRunningSound () {
        runningSound.Pause();
    }


}
