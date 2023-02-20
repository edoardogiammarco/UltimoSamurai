using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /* Game pause */
    public void pauseButtonClicked()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
    }
}
