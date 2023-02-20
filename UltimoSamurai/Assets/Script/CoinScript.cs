using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public GameObject player;


    private void OnTriggerEnter2D( Collider2D collision){

      
        if( collision.tag == "Player"){  // is there a player colliding with the coin ?
            IncrementCoinCounter();      
            Destroy(gameObject);         // destroy the coin
        }
    }

    public void IncrementCoinCounter(){
        player.GetComponent<Player>().CoinCollected();   // update the current coin of the player

    }
}
