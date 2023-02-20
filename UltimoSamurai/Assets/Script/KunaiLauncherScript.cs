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
    public AudioSource kunaiSound;
    private float timeBtwLaunchKunai;      
    public float startTimeBtwLaunchKunai = 1f;
    public float shurikenSpeed;
    public bool nowLaunchKunai;
  
    // Update is called once per frame
    void Update(){
        if(timeBtwLaunchKunai<=0) nowLaunchKunai=true;  // if is passed enough time from the last kunai attack , then you can use it again 
        else timeBtwLaunchKunai-= Time.deltaTime;       // else wait for the time to end

        
    }

    public void OnKunaiAttack(InputAction.CallbackContext ctd3){

        if(nowLaunchKunai== true){ 
             direction =  player.GetComponent<Rigidbody2D>().velocity;
             ShootKunai();
             timeBtwLaunchKunai= startTimeBtwLaunchKunai;
            }
        nowLaunchKunai= false;   // now wait before you can launch a kunai again
    }

    public void ShootKunai(){
        GameObject bullet = Instantiate(kunaiPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        kunaiSound.Play();
        
        if(direction!= Vector2.zero){ // if player is moving
            bulletRb.AddForce( new Vector2(direction.x*shurikenSpeed, direction.y*shurikenSpeed ) , ForceMode2D.Impulse);
        }
        else {   // player is not moving , launch the kunai orizontally , on the side that the playes is facing
            bulletRb.AddForce(new Vector2( player.transform.localScale.x * shurikenSpeed*3, 0 ), ForceMode2D.Impulse); 
        }



    }

}