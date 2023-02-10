using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopUpKeyboardScript : MonoBehaviour
{
    private InputField inputField;
    
    private void Awake()
    {
        inputField = GetComponent<InputField>();
    }

    public void OnPointerClick()
    {
        TouchScreenKeyboard.Open(inputField.text, TouchScreenKeyboardType.Default, false, false, false, false);
    }
}
