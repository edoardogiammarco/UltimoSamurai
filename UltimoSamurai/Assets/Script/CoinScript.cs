using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D( Collider2D collision){

  
        if( collision.tag == "Player"){
            IncrementCoinCounter();
            Destroy(gameObject);
        }
    }

    public void IncrementCoinCounter(){
        player.GetComponent<Player>().CoinCollected();

    }
}
