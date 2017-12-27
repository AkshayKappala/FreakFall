using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public Text ShowCoins;
    private void Update()
    {
        showcoins();
    }
    private void showcoins()
    {
        ShowCoins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
