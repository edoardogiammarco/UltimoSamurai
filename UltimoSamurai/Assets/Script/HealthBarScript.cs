using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBarScript : MonoBehaviour{ 
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TMP_Text myHealthPercentualText;


    /*****Health bar methods******/
    public void SetMaxHealth(int maxHealth){
        slider.maxValue= maxHealth;      // set the max value of the health bar
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
        myHealthPercentualText.text = "" + maxHealth;
    }

    public void SetHealth ( int health){
        slider.value = health;    //update the current health of the player 
        myHealthPercentualText.text = "" + health;     //update the health percentual text on the bar 
        fill.color = gradient.Evaluate(slider.normalizedValue);   //update the color of the bar 
    }
    
    public void IncreaseMaxHealth(int maxHealth){
        slider.maxValue= maxHealth+50;       
        slider.value = maxHealth+50;
        fill.color = gradient.Evaluate(1f);
        myHealthPercentualText.text = "" + (maxHealth+50);
    }

    /********Darkness bar methods*******/

    public void SetDarkness ( int darkness){
        slider.value = darkness;
    } 

    public void SetMaxDarkness(int darkness){
        slider.maxValue= 100;
        slider.value = darkness;
    }

}
