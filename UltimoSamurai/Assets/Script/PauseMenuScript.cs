using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    
    /* Resume playing button */
    public void onClickResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    /* Go back to main menu button */
    public void onClickMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    /* Exit app button */
    public void onClickExitButton()
    {
        Application.Quit();
    }
}
