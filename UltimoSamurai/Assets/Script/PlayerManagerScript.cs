using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManagerScript : MonoBehaviour
{

    public Leaderboard leaderboard;
    public TMP_InputField playerNameInputField;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName(){
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (respone)   =>{
            if ( respone.success){
                StartCoroutine(SetupRoutine());
                Debug.Log("Successfully set player name");
            }
            else {
                Debug.Log("Error"+ respone.Error);
            }

        });

    }

    IEnumerator SetupRoutine () {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighScoreRoutine();

    }

    IEnumerator LoginRoutine(){
        bool done = false ;
        LootLockerSDKManager.StartGuestSession((response) => {

            if ( response.success){
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
