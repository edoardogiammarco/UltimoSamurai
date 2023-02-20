using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{

    public AudioSource mainTheme;
    public GameObject tutorialWindow;

 
    public void GoToGameScene(){
        SceneManager.LoadScene("Main");
        mainTheme.Play();
    }
    public void GoToGameOverScene(){
        SceneManager.LoadScene("Game Over");
    }    
    public void GoToMainMenuScene(){
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToLoginScene(){
        SceneManager.LoadScene("AuthScene");
    }


/*****Main menu's Tutorial window******/
   
   
    public void ActiveTutorialWindow(){
        tutorialWindow.SetActive(true);

    }

    public void DeactiveTutorialWindow(){
        tutorialWindow.SetActive(false);

    }    

}
