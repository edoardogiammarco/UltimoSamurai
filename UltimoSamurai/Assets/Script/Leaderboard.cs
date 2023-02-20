using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

/*  
    Script for implementing a leaderboard functionality using LootLocker API.
    The Leaderboard class contains methods for submitting a player's score
    and fetching the top scores from the LootLocker server.
*/
public class Leaderboard : MonoBehaviour
{
    int leaderboardID = 11958;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerKills;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /* 
        This method takes a score to upload and the player's ID,
        submits the score to the server and waits for the response.
        If the response is successful, it logs a message and sets done to true.
    */
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID,scoreToUpload,leaderboardID, (response) => {
        
        if ( response.success){
            Debug.Log("Score submitted succesfully");
            done = true;
        }
        else {
            Debug.Log("Failed"+ response.Error);
            done = true;
        }
        });

        yield return new WaitWhile(() => done == false );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
        The FetchTopHighScoreRoutine method fetches the top scores from the server
        and displays the data on the game's UI. It waits for the response,
        checks if it is successful and iterates through the leaderboard data
        to create a string of player names and kills. It then sets done to true
        and updates the playerNames and playerKills TextMeshProUGUI objects with the leaderboard data.
    */
    public IEnumerator FetchTopHighScoreRoutine()
    {
        bool done = false ;
        LootLockerSDKManager.GetScoreListMain(leaderboardID,10,0, (respone)=>{
            if ( respone.success){
            string tempPlayerNames = "Names\n";
            string tempPlayerKills = "Enemy killed\n";

            LootLockerLeaderboardMember[] members = respone.items;

            for ( int i = 0 ; i< members.Length ;  i++)
            {
                tempPlayerNames+= members[i].rank + ". ";

                if ( members[i].player.name != "")
                {
                    tempPlayerNames += members[i].player.name;
                }
                else{
                    tempPlayerNames += members[i].player.id;
                }

                tempPlayerKills += members[i].score + "\n";
                tempPlayerNames += "\n";
            }

            done = true ;
            playerNames.text = tempPlayerNames;
            playerKills.text = tempPlayerKills;
        }

        else {
            Debug.Log("Failed" + respone.Error);
            done = true;
        }
        });

        yield return new WaitWhile(() => done == false );

    }
}
