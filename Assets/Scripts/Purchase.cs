using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Khadga.Yodha.Prasanth;

public class Purchase : MonoBehaviour {
    public GameObject ThemeLocker;

    public void BuyAllCharcs()
    {
        IAPManager.instance.UnlockAll();
        //PlayerPrefs.SetInt("isUnlocked", 5);
        //ThemeLocker.SetActive(false);
    }

}
