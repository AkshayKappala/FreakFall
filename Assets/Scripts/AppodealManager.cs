using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;

public class AppodealManager : MonoBehaviour, IRewardedVideoAdListener, IBannerAdListener, IInterstitialAdListener
{

    public static AppodealManager AppodealInstance;

    public delegate void RewardedVideoClosed(string type);
    public static event RewardedVideoClosed OnRewardedVideoClose;

    public string PreviousInstruction;

    int InterstitialIterator = 0;
    public int InterstitialVideoInterval = 4;
    public int RewardCoins = 200;


    void Awake()
    {
        Appodeal.disableNetwork("yandex");
        if (AppodealInstance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            AppodealInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        string appKey = "93919d9c6baab5864bfdab3f73122d50a4454c4e9b1b2a63";
        Appodeal.disableLocationPermissionCheck();
        Appodeal.setTesting(true);
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.REWARDED_VIDEO);
        Appodeal.setRewardedVideoCallbacks(this);
        Appodeal.setBannerCallbacks(this);
    }

    public void ShowBannerAd()
    {
        if (Appodeal.isLoaded(Appodeal.BANNER))
        {
            Appodeal.show(Appodeal.BANNER_TOP);
        }
    }

    public void HideBannerAd()
    {
        Appodeal.hide(Appodeal.BANNER);
    }

    public void ShowInterstetialAd()
    {
        InterstitialIterator++;

        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL) && InterstitialIterator >= InterstitialVideoInterval)
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
            InterstitialIterator = 0;
        }
    }

    public void ShowRewardedAd()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
        else
        {
            Debug.Log("Rewarded video not loaded");
            if(GameObject.Find("UIManager"))
                UIManager.Instance.NoAds();
            if(GameObject.Find("GameController"))
                GameObject.Find("GameController").GetComponent<GameController>().NoAdsAvailable.SetActive(true);
        }
    }

    #region Rewarded_Video callbacks
    public void onRewardedVideoLoaded() { Debug.Log("Rewarded video loaded"); }
    public void onRewardedVideoFailedToLoad() { Debug.Log("Rewarded video failed to load"); }
    public void onRewardedVideoShown() { Debug.Log("Rewarded video shown"); }
   
    public void onRewardedVideoClosed(bool finished)
    {
        Debug.Log("reward closed at " + Time.realtimeSinceStartup);
        OnRewardedVideoClose(PreviousInstruction);


    }
    #endregion

    #region Banner callbacks
    public void onBannerLoaded(bool isPrecache) { Debug.Log("Banner Ad loaded"); }
    public void onBannerFailedToLoad() { Debug.Log("Banner Ad failed to load"); }
    public void onBannerShown() { Debug.Log("Banner Ad shown"); }
    public void onBannerClicked() { Debug.Log("Banner Ad closed"); }
    #endregion

    #region Interstitial_Video callbacks
    public void onInterstitialLoaded(bool isPrecache) { Debug.Log("Interstitial video loaded"); }
    public void onInterstitialFailedToLoad() { Debug.Log("Interstitial video failed to load"); }
    public void onInterstitialShown() { Debug.Log("Interstitial video shown"); }
    public void onInterstitialClicked() { Debug.Log("Interstitial video clicked"); }
    public void onInterstitialClosed() { Debug.Log("Interstitial video closed"); }

    public void onRewardedVideoFinished(int amount, string name)
    {
        Debug.Log("reward video finished at " + Time.realtimeSinceStartup);
    }
    #endregion

}
