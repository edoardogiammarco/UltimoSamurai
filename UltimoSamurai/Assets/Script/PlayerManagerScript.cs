using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

/*
    This script contains a few methods for managing the 
    player's information and integrating it with the LootLocker API.
*/
public class PlayerManagerScript : MonoBehaviour
{
    public Leaderboard leaderboard;
    public TMP_InputField playerNameInputField;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    /*
        This method is called when the player inputs a name in the input field 
        and clicks the "Set Name" button. This method sets the player's name in LootLocker
        by calling the SetPlayerName() method from the LootLockerSDKManager class.
    */
    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (respone)   =>{
            if ( respone.success)
            {
                StartCoroutine(SetupRoutine());
                Debug.Log("Successfully set player name");
            }
            else {
                Debug.Log("Error"+ respone.Error);
            }

        });

    }

    /*
        This method runs an IEnumerator method SetupRoutine() that logs the player in
        as a guest and fetches the top high scores from the LootLocker API
        by calling the FetchTopHighScoreRoutine() method from the Leaderboard class.
    */
    IEnumerator SetupRoutine ()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighScoreRoutine();
    }

    /*
        This method logs the player in as a guest by calling the
        StartGuestSession() method from the LootLockerSDKManager class.
    */
    IEnumerator LoginRoutine()
    {
        bool done = false ;
        LootLockerSDKManager.StartGuestSession((response) => {

            if ( response.success)
            {
                Debug.Log("Player logged in");
                PlayerPrefs.SetString("PlayerID",response.player_id.ToString());
                done = true;
            }
            else{
                Debug.Log("Can't start the session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
