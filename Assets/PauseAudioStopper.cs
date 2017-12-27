using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudioStopper : MonoBehaviour {
    public GameObject AudioListener;
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            if (AudioListener.activeSelf)
                AudioListener.SetActive(false);
        }
        else
        {
            if (!AudioListener.activeSelf)
                AudioListener.SetActive(true);
        }
    }
}
