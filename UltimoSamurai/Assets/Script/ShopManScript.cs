using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManScript : MonoBehaviour
{
        public GameObject shop;
        


        public void OnTriggerEnter2D ( Collider2D collider){ // if the player is collidin with the shop man
        if(collider.tag == "Player"){
            
            Time.timeScale = 0f;   //  freeze game time
             
            shop.SetActive(true);  // open the shop

        }

    }
}
