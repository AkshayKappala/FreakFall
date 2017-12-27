using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostIconController : MonoBehaviour {
    public GameObject BoostButton;
    private void OnTriggerExit(Collider other)
    {
        BoostButton.SetActive(false);
    }
}
