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
    // Start is called before the first frame update
    void Start()
    {
        myPowerUpText.text =   "       Current Stats" + "\n" + "  Luck:"           +  enemy.GetComponent<BaseEnemyScript>().GetLuck()
                               + "\n"+ "  StrenGth Bonus:"          +  player.GetComponent<PlayerCombat>().getAttackBonus()
                               + "\n"+  "  Critical Hit Chance(%):" +  player.GetComponent<PlayerCombat>().getCriticalHitProbability()
                               + "\n"+ "  Current Max Health:"      +  player.GetComponent<Player>().CurrentMaxHealth() ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCurrentPowerUpState (){
        myPowerUpText.text = "       Current Stats" + "\n" + "  Luck:"           +  enemy.GetComponent<BaseEnemyScript>().GetLuck()
                               + "\n"+ "  StrenGth Bonus:"          +  player.GetComponent<PlayerCombat>().getAttackBonus()
                               + "\n"+  "  Critical Hit Chance(%):" +  player.GetComponent<PlayerCombat>().getCriticalHitProbability()
                               + "\n"+ "  Current Max Health:"      +  player.GetComponent<Player>().CurrentMaxHealth() ;
        
    }
}
