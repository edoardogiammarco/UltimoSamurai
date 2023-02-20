using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KunaiLauncherScript : MonoBehaviour
{
    public GameObject player;
    public GameObject kunaiPrefab;
    public Transform firePoint;
    public Vector2 direction;

    private float timeBtwLaunchKunai;      
    public float startTimeBtwLaunchKunai = 1f;
    public float shurikenSpeed;
    public bool nowLaunchKunai;
  
    // Update is called once per frame
    void Update(){
        if(timeBtwLaunchKunai<=0) nowLaunchKunai=true;
        else timeBtwLaunchKunai-= Time.deltaTime;

        
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
        
        if(direction!= Vector2.zero){ // if player is moving
            bulletRb.AddForce( new Vector2(direction.x*shurikenSpeed, direction.y*shurikenSpeed ) , ForceMode2D.Impulse);
        }
        else { 
            bulletRb.AddForce(new Vector2( player.transform.localScale.x * shurikenSpeed*3, 0 ), ForceMode2D.Impulse); 
        }

    }

}