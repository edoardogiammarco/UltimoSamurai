using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power_UpScript : MonoBehaviour
{
    public GameObject playerGameObject;
    public GameObject enemyGameObject;
    public GameObject shop;
    public GameObject healthBar;
    public GameObject currentPowerUpStatus;
    private int luckPrice = 5;
    private int strengthPrice = 5;
    private int criticalHitPrice= 3;
    private int incrementHealthPrice = 15;
    private int newCurrentCoin;
    private int newCurrentMaxHealth;

    void Start(){
        shop.SetActive(false);
    }

    
    public void IncreaseCriticalHitProbability(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - criticalHitPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);
            // aggiorna valore critical hit
            playerGameObject.GetComponent<PlayerCombat>().AddCriticalHitProbability();
            // aggiorna stato parametri
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();
            
        }

        
    }

    public void IncreaseLuck(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - luckPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);
            // aggiorna valore critical hit
            enemyGameObject.GetComponent<BaseEnemyScript>().setLuck();
            // aggiorna stato parametri
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();
            
        }


    }

    public void IncreaseMaxHealth(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - incrementHealthPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);

            // aggiorna valore maxhealth su script bar script
            healthBar.GetComponent<HealthBarScript>().IncreaseMaxHealth(playerGameObject.GetComponent<Player>().CurrentMaxHealth());
            // aggiorna valore currhealth su player script
            newCurrentMaxHealth = 50 + playerGameObject.GetComponent<Player>().CurrentMaxHealth();
            playerGameObject.GetComponent<Player>().SetMaxHealth(newCurrentMaxHealth);
            // aggiorna stato parametri
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();

            
        } 


    }

    public void IncreaseStrength(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - strengthPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);
            playerGameObject.GetComponent<Player>().SetCurrentCoin(newCurrentCoin);

            // aggiorna valore strength
            playerGameObject.GetComponent<PlayerCombat>().AddStrength();
            // aggiorna stato parametri
            currentPowerUpStatus.GetComponent<CurrentPowerUpScript>().updateCurrentPowerUpState();

            
        }        

    }
    public void ExitButton(){
        Time.timeScale = 1f;
        shop.SetActive(false);

    }
}
