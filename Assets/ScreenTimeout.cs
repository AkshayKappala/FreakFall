using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTimeout : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
