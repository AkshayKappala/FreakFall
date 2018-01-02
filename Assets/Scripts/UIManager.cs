using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject GameOverMenu;
    public GameObject LoadingScreen0;
    public GameObject Wallet;
    public GameObject ScoreWallet;
    public GameObject Score;
    public GameObject GameOverLayer;
    public GameObject NoCoins;
    public GameObject NoCoinsForBoost;
    public GameObject BoostButton;
    public GameObject NoAdsAvailable;
    private GameObject AudioListener;
    public GameObject Resumer321;
    public int score = 0;
    public Text Scoreboard;
    public Text SoundOnOffText;
    public int HighScore;
    public Text SetHighScore;
    public int TileSpeed;
    //public AppodealManager ADM;

    //public bool isAnythingLower;

    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        HighScore = PlayerPrefs.GetInt("HighScore");
        sethighscore();

    }

    private void OnEnable()
    {
        //AppodealManager.OnRewardedVideoClose += GiveRevive;
    }

    public void GiveRevive(string str)
    {
        /*if (str == "revive")
        {
            Debug.Log(str);
            Debug.Log("GiveRevive");

            //GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * BasicTileScript.StartVelocity * 2);
        }*/
        //Pause();
    }

    private void Start()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        GameOverLayer.SetActive(false);
        setScoreboard();
        SetHighScore.text = "High Score : " + HighScore.ToString();
    }

    private void Update()
    {
        setScoreboard();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PauseMenu.activeSelf&&SceneManager.GetActiveScene().name!="MainMenu")
            {
                Pause();
            }
        }
    }

    public void Boost()
    {
        if (PlayerPrefs.GetInt("Coins") >= 50)
        {
            TileSpeed += 200;
            BoostButton.SetActive(false);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 50);
        }
        else
        {
            NoCoinsForBoost.SetActive(true);
        }
    }

    public void Resume321()
    {
        Debug.Log("Animation time scale fixed at "+Time.realtimeSinceStartup);
        Time.timeScale = 1;
    }

    public void ShowGameOverMenu()
    {
        NoAdsAvailable.SetActive(false);
        PauseButton.SetActive(false);
        PauseMenu.SetActive(false);
        NoCoins.SetActive(false);
        sethighscore();
        Time.timeScale = 0;
        //GameOverLayer.SetActive(true);
        StartCoroutine(ShowGameOverMenuIE());
    }

    public void CloseGameOverMenu()
    {
        /*Debug.Log("Animation called at " + Time.realtimeSinceStartup);

        //Resumer321.GetComponent<Animator>().SetTrigger("Call321");
        //StartCoroutine(xyz());
       // Debug.Log("Play321");
        //resume();*/
        StartCoroutine(CloseGameoverMenuio());

        GameOverMenu.GetComponent<Animator>().Play("GameOverMenuClose");
    }

    /*IEnumerator xyz()
    {
        yield return new WaitForSeconds(2);
    }*/

    public void CloseGameOverMenu(int a)
    {
        StartCoroutine(CloseGameoverMenuio());
        GameOverMenu.GetComponent<Animator>().Play("GameOverMenuClose");
    }

    IEnumerator CloseGameoverMenuio()
    {
        yield return new WaitForSecondsRealtime(0.21f);
        NoCoins.SetActive(false);
        NoAdsAvailable.SetActive(false);
        PauseButton.SetActive(true);
        GameOverMenu.SetActive(false);

        //StartCoroutine(CloseGameOverLayer());
    }

    /*IEnumerator CloseGameOverLayer()
    {
        yield return new WaitForSecondsRealtime(3.21f);
        GameOverLayer.SetActive(false);


    }*/


    public void Pause()
    {
        if (!GameOverMenu.activeSelf)
        {
           /* AudioListener = GameObject.FindObjectOfType<AudioListener>().gameObject;
            AudioListener.SetActive(false);*/
            Time.timeScale = 0;
            PauseButton.SetActive(false);
            PauseMenu.SetActive(true);
            GameOverLayer.SetActive(true);
        }
    }
    public void Pause(int a)
    {
      
            Time.timeScale = 0;
            PauseButton.SetActive(false);
            PauseMenu.SetActive(true);
            GameOverLayer.SetActive(true);
    }

    public void resume()
    {
        if (AudioListener)
            AudioListener.SetActive(true);
        Resumer321.GetComponent<Animator>().SetTrigger("Call321");
        Debug.Log("Play 321");

        //StartCoroutine(CloseGameOverLayer());
        StartCoroutine(resumeio());
        PauseMenu.GetComponent<Animator>().Play("PauseClose");
    }

    public void resume(int a)
    {
        if (AudioListener)
            AudioListener.SetActive(true);
        //StartCoroutine(CloseGameOverLayer());
        StartCoroutine(resumeio());
        PauseMenu.GetComponent<Animator>().Play("PauseClose");
    }

    IEnumerator resumeio()
    {
        yield return new WaitForSecondsRealtime(0.2f);
       
        if(!GameObject.Find("GameController"))
            PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void SoundToggle()
    {
        if(PlayerPrefs.GetInt("Soundpref")==1)
        {
            PlayerPrefs.SetInt("Soundpref", 0);
            SoundOnOffText.text = "Sound : off";
        }
        else if (PlayerPrefs.GetInt("Soundpref") == 0)
        {
            PlayerPrefs.SetInt("Soundpref", 1);
            SoundOnOffText.text = "Sound : on";
        }

        var objs = FindObjectsOfType<AudioSource>();
        foreach (var item in objs)
        {
            item.volume = PlayerPrefs.GetInt("Soundpref");
        }


    }

    public void gotomenu()
    {
        resume(3);
        LoadingScreen0.SetActive(true);
        /*PauseButton.SetActive(false);
        PauseMenu.SetActive(false);*/

        Time.timeScale = 1.0f;
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        PauseButton.SetActive(false);
        ScoreWallet.SetActive(false);
        Scoreboard.text = null;
        sethighscore();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Revive()
    {
        if (PlayerPrefs.GetInt("Coins") >= 200)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            CloseGameOverMenu();
           // GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * BasicTileScript.StartVelocity * 2);
        }

        else
        {
            NoCoins.SetActive(true);
        }
    }

    public void AdnRevive()
    {
        AppodealManager.AppodealInstance.PreviousInstruction = "revive";
        AppodealManager.AppodealInstance.ShowRewardedAd();
        CloseGameOverMenu();
        PauseButton.SetActive(false);
        Pause(1);
        //ADM.ShowRewardedAd();
    }

    public void NoAds()
    {
        if (GameOverMenu.activeSelf)
            NoAdsAvailable.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        CloseGameOverMenu(1);
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    void setScoreboard()
    {
        Scoreboard.text = score.ToString();
    }

    void sethighscore()
    {
       // if (SetHighScore != null)
       if(score>=PlayerPrefs.GetInt("HighScore"))
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            GooglePlayGamesManager.Instance.PostScoreToLB();
            SetHighScore.text = "High Score : " + HighScore.ToString();
        }
    }



    IEnumerator ShowGameOverMenuIE()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        GameOverMenu.SetActive(true);
        GameOverLayer.SetActive(true);
    }

    public void OnApplicationPause(bool pause)
    {

       if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            Pause();
        }

   
    }
    public void OnApplicationFocus(bool focus)
    {
        if(SceneManager.GetActiveScene().name!="Gameplay")
        {
            //   resume();
        }
    }
}