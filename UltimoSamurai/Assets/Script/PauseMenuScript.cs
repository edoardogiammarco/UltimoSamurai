using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{


    public GameObject pauseMenu;
    

    public void onClickResumeButton(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void onClickMainMenuButton(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        
    }

    public void onClickExitButton(){
        Application.Quit();
        
    }
}
