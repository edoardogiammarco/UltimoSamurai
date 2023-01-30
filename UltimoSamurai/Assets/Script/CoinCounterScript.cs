using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinCounterScript : MonoBehaviour
{
    public TMP_Text myScoreText;
    private int scoreNum;
    // Start is called before the first frame update
    void Start()
    {
        scoreNum = 0;
        myScoreText.text = ""+ scoreNum;
        
    }

    public void updateCoinCounter(int currentCoin){
        myScoreText.text = ""+ currentCoin;
    }
}
