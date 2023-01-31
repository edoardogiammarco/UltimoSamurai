using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_UpScript : MonoBehaviour
{
    private GameObject playerGameObject;
    private int luckCostPrice = 20;
    private int strengthCostPrice = 10;
    private int criticalHitPrice= 2;
    private int incrementHealthPrice = 15;
    public GameObject shop;

    void Start(){
        shop.SetActive(false);
    }

    
    public void IncreaseCriticalHitProbability(){
        if(playerGameObject.GetComponent<Player>().getCurrentCoin() - criticalHitPrice>=0){
            // aggiorna valore monete
            // aggiorna valore critical hit
        }

        
    }

    public void IncreaseLuck(){

    }

    public void IncreaseMaxHealth(){

    }

    public void IncreaseStrength(){

    }
    public void ExitButton(){
        Time.timeScale = 1f;
        shop.SetActive(false);

    }
}
