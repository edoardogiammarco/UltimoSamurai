using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    public void GoToGameScene(){
        SceneManager.LoadScene("Main");
    }
        public void GoToGameOverScene(){
        SceneManager.LoadScene("Game Over");
    }    
    public void GoToMainMenuScene(){
        SceneManager.LoadScene("Main Menu");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
