using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class GooglePlayGamesManager : MonoBehaviour {
    public static GooglePlayGamesManager Instance;
    string LeaderBoardsID = "CgkIxbbEzcEcEAIQAA";
    private void Awake()
    {
       // Debug.LogError("print");
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        PlayGamesPlatform.Activate();

        Debug.Log("google authentication called");
        Social.localUser.Authenticate((bool success) => {
            Debug.Log("login status:" + success);
        });
    }
    public void Start()
    {
        if (!Social.localUser.authenticated)
        {
            Authenticate();
        }
    }

    public void Authenticate()
    {
        Debug.Log("Attempting to Login PlayServices");
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("PlayServices Login success");
            }
            else
            {
                Debug.Log("PlayServices Login failed");

            }
            Debug.Log("====================="+Social.localUser.userName);
        });
    }

    // Play Services Leaderboards

    #region GOOGLE_PLAY_SERVICES

    public void PostScoreToLB()
    {

        if (Social.localUser.authenticated)
        {
            //Edit by Naveen enable this while uploading into google play store
            PostScore();
        }
        else
        {

        }
    }

    void PostScore()
    {
        Social.ReportScore(UIManager.Instance.HighScore, LeaderBoardsID, (bool success) =>
        {
            if (success)
            {
                // score posted to LB
            }
            else
            {
                // score not posted to LB
            }
        });


    }

    public void DisplayLB()
    {
        Debug.Log("Leaderboard icon clicked");
        if (Social.localUser.authenticated)
        {
            Debug.LogWarning("LeaderBoardsID UI" + LeaderBoardsID);
            Social.ShowLeaderboardUI();
        }
        else
        {
            // Failed to get Leaderboard
            Debug.Log("Failed to get Leaderboard");
            Authenticate();
        }

    }
    #endregion
    
}
