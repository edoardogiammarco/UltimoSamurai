using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power_UpScript : MonoBehaviour
{
    /* GameObject references */
    public GameObject playerGameObject;
    public GameObject enemyGameObject;
    public GameObject shop;
    public GameObject healthBar;
    public GameObject currentPowerUpStatus;

    /* AudioSource reference */
    public AudioSource achievementUnlocked;

    /* Power up prices */
    private int luckPrice = 5;
    private int strengthPrice = 5;
    private int criticalHitPrice= 3;
    private int incrementHealthPrice = 15;

    /* New updated values */
    private int newCurrentCoin;
    private int newCurrentMaxHealth;
    
    void Start()
    {
        shop.SetActive(false);
    }
    
    public void IncreaseCriticalHitProbability()
    {
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - criticalHitPrice;

        if( newCurrentCoin>=0)
        {
            // Update coin value
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);
            // Play achievement sound
             PlayAchievementSound();
            // Update critical hit value
            playerGameObject.GetComponent<PlayerCombat>().AddCriticalHitProbability();
            // Update parameters status
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();
        } 
    }

    public void IncreaseLuck()
    {
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - luckPrice;

        if( newCurrentCoin>=0)
        {
            // Update coin value
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);
            // Play achievement sound
            PlayAchievementSound();
            // aggiorna valore critical hit
            playerGameObject.GetComponent<Player>().setLuck();
            // Update parameters status
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();
        }
    }

    public void IncreaseMaxHealth()
    {
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - incrementHealthPrice;

        if( newCurrentCoin>=0){
            // Update coin value
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);
            // Play achievement sound
            PlayAchievementSound();
            // Update maxhelath value on healthbar script
            healthBar.GetComponent<HealthBarScript>().IncreaseMaxHealth(playerGameObject.GetComponent<Player>().CurrentMaxHealth());
            // Update currhealth value on player script
            newCurrentMaxHealth = 50 + playerGameObject.GetComponent<Player>().CurrentMaxHealth();
            playerGameObject.GetComponent<Player>().SetMaxHealth(newCurrentMaxHealth);
            // Update parameters status
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();
        }
    }

    public void IncreaseStrength()
    {
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - strengthPrice;

        if( newCurrentCoin>=0)
        {
            // Update coin value
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);
            // Play achievement sound
            PlayAchievementSound();
            // Update strength value
            playerGameObject.GetComponent<PlayerCombat>().AddStrength();
            // Updata parameters status
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();
        }        
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        shop.SetActive(false);
    }

    public void PlayAchievementSound()
    {
        achievementUnlocked.Play();
    }
}
