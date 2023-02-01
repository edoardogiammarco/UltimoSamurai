using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CurrentPowerUpScript : MonoBehaviour
{
    public TMP_Text myPowerUpText;
    // Start is called before the first frame update
    void Start()
    {
        myPowerUpText.text = "Current" + "\n" + "Luck:";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
