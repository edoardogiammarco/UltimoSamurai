using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinCounterScript : MonoBehaviour
{
    public TMP_Text myScoreText;
    private int scoreNum;
    
    /*This script initialize and update the coin counter text*/

    void Start()
    {
        scoreNum = 0;
        myScoreText.text = ""+ scoreNum;
        
    }

    public void updateCoinCounter(int currentCoin){
        myScoreText.text = ""+ currentCoin;
    }
}
