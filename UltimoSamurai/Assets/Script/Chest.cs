using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
public Sprite emptyChest; 
public int goldAmount ;

    private void OnCollisionEnter2D(Collision2D collision){
       
            
            GetComponent<SpriteRenderer>().sprite = emptyChest;

    }

    
}
