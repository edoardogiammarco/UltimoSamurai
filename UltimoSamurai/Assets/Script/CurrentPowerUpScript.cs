using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentPowerUpScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public TMP_Text myPowerUpText;

    /*
        This piece of code refreshes and displays on screen
        the updated values for the player's stats, such as
        Luck in coin drops, Attack power increase,
        Critical hit chance on basic attacks and the current
        player's max health
    */
    
    void Start()
    {
        myPowerUpText.text =   "       Current Stats" + "\n" + "  Luck:"           +  player.GetComponent<Player>().GetLuck()
                               + "\n"+ "  Strength Bonus:"                         +  player.GetComponent<PlayerCombat>().getAttackBonus()
                               + "\n"+  "  Critical Hit Chance(%):"                +  player.GetComponent<PlayerCombat>().getCriticalHitProbability()
                               + "\n"+ "  Current Max Health:"                     +  player.GetComponent<Player>().CurrentMaxHealth() ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCurrentPowerUpState (){
        myPowerUpText.text = "       Current Stats" + "\n" + "  Luck:"           +  player.GetComponent<Player>().GetLuck()
                               + "\n"+ "  Strength Bonus:"                       +  player.GetComponent<PlayerCombat>().getAttackBonus()
                               + "\n"+  "  Critical Hit Chance(%):"              +  player.GetComponent<PlayerCombat>().getCriticalHitProbability()
                               + "\n"+ "  Current Max Health:"                   +  player.GetComponent<Player>().CurrentMaxHealth() ;
        
    }
}
