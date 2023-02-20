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
  
    /*
        The Update() method is used to update the cooldown time between kunai launches.
        It checks if timeBtwLaunchKunai has passed and sets nowLaunchKunai to true if it has.
        It also decreases timeBtwLaunchKunai by Time.deltaTime.
    */
    void Update()
    {
        if(timeBtwLaunchKunai<=0) nowLaunchKunai=true;
        else timeBtwLaunchKunai-= Time.deltaTime;        
    }

    public void OnKunaiAttack(InputAction.CallbackContext ctd3)
    {
        if(nowLaunchKunai== true)
        { 
            direction =  player.GetComponent<Rigidbody2D>().velocity;
            ShootKunai();
            timeBtwLaunchKunai= startTimeBtwLaunchKunai;
            }
        nowLaunchKunai= false;
    }

    /*
        This method instantiates a new kunai projectile at the firePoint position,
        and adds a force to it based on the direction in which it should be launched.
        If the player is moving, the kunai is launched in the same direction as the player's movement.
        If the player is not moving, the kunai is launched in the direction of the player's facing, 
        multiplied by a constant value.
    */
    public void ShootKunai()
    {
        GameObject bullet = Instantiate(kunaiPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        
        // If player is moving
        if(direction!= Vector2.zero)
        {   
            bulletRb.AddForce( new Vector2(direction.x*shurikenSpeed, direction.y*shurikenSpeed ) , ForceMode2D.Impulse);
        }
        else { 
            bulletRb.AddForce(new Vector2( player.transform.localScale.x * shurikenSpeed*3, 0 ), ForceMode2D.Impulse); 
        }
    }
}