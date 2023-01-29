using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HealthBarScript : MonoBehaviour{ 
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health){
        slider.maxValue= health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth ( int health){
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxDarkness(int darkness){
        slider.maxValue= 100;
        slider.value = darkness;
    }


}
