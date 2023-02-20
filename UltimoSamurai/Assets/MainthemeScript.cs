using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainthemeScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if( !gameObject.GetComponent<AudioSource>().isPlaying ){  // loop the main theme
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
