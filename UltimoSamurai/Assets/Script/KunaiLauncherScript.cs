using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KunaiLauncherScript : MonoBehaviour
{
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        
    }

    
        
    public void OnKunaiAttack(InputAction.CallbackContext ctd3){
            ShootKunai();
    }

    public void ShootKunai(){
        Debug.Log("Kunai Lanciato");
    }

}