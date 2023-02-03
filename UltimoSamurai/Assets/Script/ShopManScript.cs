using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManScript : MonoBehaviour
{
        public GameObject shop;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void OnTriggerEnter2D ( Collider2D collider){
        if(collider.tag == "Player"){
            // apri il menu
            Time.timeScale = 0f;
            
            shop.SetActive(true);   

        }

    }
}
