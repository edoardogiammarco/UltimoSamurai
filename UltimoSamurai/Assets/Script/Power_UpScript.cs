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
    private int luckPrice = 5;
    private int strengthPrice = 5;
    private int criticalHitPrice= 3;
    private int incrementHealthPrice = 15;
    private int newCurrentCoin;

    void Start(){
        shop.SetActive(false);
    }

    
    public void IncreaseCriticalHitProbability(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - criticalHitPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);

            // aggiorna valore critical hit
            playerGameObject.GetComponent<PlayerCombat>().AddCriticalHitProbability();
            
        }

        
    }

    public void IncreaseLuck(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - luckPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);

            // aggiorna valore critical hit
            enemyGameObject.GetComponent<BaseEnemyScript>().setLuck();
            
        }


    }

    public void IncreaseMaxHealth(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - incrementHealthPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);

            // aggiorna valore maxhealth su script bar script
            healthBar.GetComponent<HealthBarScript>().IncreaseMaxHealth(playerGameObject.GetComponent<Player>().GetMaxHealth());
            // aggiorna valore currhealth su player script
            // CORREGGI QUESTA LINEA SOTTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            playerGameObject.GetComponent<Player>().SetMaxHealth(150);

            
        } 


    }

    public void IncreaseStrength(){
        newCurrentCoin= playerGameObject.GetComponent<Player>().getCurrentCoin() - strengthPrice;

        if( newCurrentCoin>=0){
            // aggiorna valore monete
            playerGameObject.GetComponent<CoinCounterScript>().updateCoinCounter(newCurrentCoin);

            // aggiorna valore strength
            playerGameObject.GetComponent<PlayerCombat>().AddStrength();

            
        }        

    }
    public void ExitButton(){
        Time.timeScale = 1f;
        shop.SetActive(false);

    }
}
