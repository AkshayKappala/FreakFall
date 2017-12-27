using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume321 : MonoBehaviour
{
    public void Resume321go()
    {
        UIManager.Instance.Resume321();
        UIManager.Instance.GameOverLayer.SetActive(false);
    }
}
