using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


 /*This script show the text of the current power up on the shop*/ 


public class CurrentPowerUpScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public TMP_Text myPowerUpText;
   
    void Start()
    {
        myPowerUpText.text =   "       Current Stats" + "\n" + "  Luck:"           +  player.GetComponent<Player>().GetLuck()
                               + "\n"+ "  Strength Bonus:"                         +  player.GetComponent<PlayerCombat>().getAttackBonus()
                               + "\n"+  "  Critical Hit Chance(%):"                +  player.GetComponent<PlayerCombat>().getCriticalHitProbability()
                               + "\n"+ "  Current Max Health:"                     +  player.GetComponent<Player>().CurrentMaxHealth() ;

    }



    public void updateCurrentPowerUpState (){
        myPowerUpText.text = "       Current Stats" + "\n" + "  Luck:"           +  player.GetComponent<Player>().GetLuck()
                               + "\n"+ "  Strength Bonus:"                       +  player.GetComponent<PlayerCombat>().getAttackBonus()
                               + "\n"+  "  Critical Hit Chance(%):"              +  player.GetComponent<PlayerCombat>().getCriticalHitProbability()
                               + "\n"+ "  Current Max Health:"                   +  player.GetComponent<Player>().CurrentMaxHealth() ;
        
    }
}
