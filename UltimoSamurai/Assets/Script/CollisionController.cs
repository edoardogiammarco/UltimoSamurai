using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D( Collision2D collision){
        if(collision.gameObject.CompareTag("Chest")){
            
        }
        if(collision.gameObject.CompareTag("Enemy")){
                GoToGameOverScene();
            
        }
        
    }
        public void GoToGameOverScene(){
        SceneManager.LoadScene("Game Over");
    }

     
}
