using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMScore : MonoBehaviour
{
    public int HighScore;
    public Text SetHighScore;
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        sethighscore();
    }

    void sethighscore()
    {
        SetHighScore.text = "High Score : " + HighScore.ToString();
    }
}
