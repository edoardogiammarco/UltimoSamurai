using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KunaiLauncherScript : MonoBehaviour
{
    public GameObject player;
    public Transform firePoint;
    public GameObject kunaiPrefab;
    private float timeBtwLaunchKunai;      
    public float startTimeBtwLaunchKunai = 1f;
    public bool nowLaunchKunai;
    public Vector2 direction;
    public float force = 0.0005f;
    // Update is called once per frame
    void Update()
    {
        if(timeBtwLaunchKunai<=0) nowLaunchKunai=true;
        else timeBtwLaunchKunai-= Time.deltaTime;

//        Debug.Log(player.GetComponent<Rigidbody2D>().velocity);
        
    }

    
        
    public void OnKunaiAttack(InputAction.CallbackContext ctd3){

        if(nowLaunchKunai== true){ 
            direction =  player.GetComponent<Rigidbody2D>().velocity;     
             ShootKunai();
             timeBtwLaunchKunai= startTimeBtwLaunchKunai;
            }
        nowLaunchKunai= false;
    }

    public void ShootKunai(){
        GameObject bullet = Instantiate(kunaiPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce( direction*force, ForceMode2D.Impulse);
    }



}