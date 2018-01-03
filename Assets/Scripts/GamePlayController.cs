using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public int ThemeNumber;
    public GameObject BGMusic;
    public GameObject MainCamera;
    public GameObject Plane;
    public GameObject BackgroundImage;
    public Sprite BG1;
    public Sprite BG2;
    public Sprite BG3;
    private void Awake()
    {
       
        SoundManagement();
        ThemeNumber = GameController.theme;
        switch (ThemeNumber)
        {
            case 1: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG1; break;
            case 2: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG2; break;
            case 3: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG3; break;
        }

    }


    public void SoundManagement()
    {
        var objs = FindObjectsOfType<AudioSource>();
        foreach (var item in objs)
        {
            item.volume = PlayerPrefs.GetInt("Soundpref");
        }
    }

    void playBG()
    {
        BGMusic.GetComponent<AudioSource>().PlayDelayed(2);
    }

    public  void Start()
    {
        UIManager.Instance.Resumer321.SetActive(true);
        UIManager.Instance.LoadingScreen0.SetActive(false);
        UIManager.Instance.BoostButton.SetActive(true);
        UIManager.Instance.NoCoinsForBoost.SetActive(false);
        SoundManagement();
        playBG();
        UIManager.Instance.PauseButton.SetActive(true);
        UIManager.Instance.PauseMenu.SetActive(false);
        UIManager.Instance.GameOverLayer.SetActive(false);
        UIManager.Instance.Wallet.SetActive(true);
        UIManager.Instance.ScoreWallet.SetActive(true);
        UIManager.Instance.score = 0;
        UIManager.Instance.TileSpeed = 0;
        UIManager.Instance.resume(1);
        Instantiate(Resources.Load(ThemeNumber + "RescueCharGreen"), new Vector3(0, 23.2f, 0), Quaternion.identity);
        initialSoundSettingPreview();
        BackgroundImage.transform.position = new Vector3(0, 0, 0);
    }

    void initialSoundSettingPreview()
    {
        if (PlayerPrefs.GetInt("Soundpref") == 1)
        {
            UIManager.Instance.SoundOnOffText.text = "Sound : on";
        }
        else if (PlayerPrefs.GetInt("Soundpref") == 0)
        {
            UIManager.Instance.SoundOnOffText.text = "Sound : off";
        }
    }

}
