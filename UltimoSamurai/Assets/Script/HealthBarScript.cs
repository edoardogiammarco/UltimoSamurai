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

    public void SetMaxHealth(int maxHealth){
        slider.maxValue= maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
        myHealthPercentualText.text = "" + maxHealth;
    }

    public void SetHealth ( int health){
        slider.value = health;
        myHealthPercentualText.text = "" + health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxDarkness(int darkness){
        slider.maxValue= 100;
        slider.value = darkness;
    }
        public void IncreaseMaxHealth(int maxHealth){
        slider.maxValue= maxHealth+50;
        slider.value = maxHealth+50;
        fill.color = gradient.Evaluate(1f);
        myHealthPercentualText.text = "" + (maxHealth+50);
    }


}
