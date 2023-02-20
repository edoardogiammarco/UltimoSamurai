using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject pauseMenu;


    public void pauseButtonClicked(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;      // freeze game time when pause menu button is pressed

    }


}
