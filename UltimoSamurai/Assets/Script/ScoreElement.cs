using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text killsText;
    public TMP_Text wavesText;
    public TMP_Text pointsText;

    public void NewScoreElement (string _username, int _kills, int _waves, int _points)
    {
        usernameText.text = _username;
        killsText.text = _kills.ToString();
        wavesText.text = _waves.ToString();
        pointsText.text = _points.ToString();
    }

}
