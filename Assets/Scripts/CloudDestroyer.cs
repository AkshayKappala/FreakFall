using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDestroyer : MonoBehaviour {

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Clouds"))
        {
            Destroy(other.gameObject);
        }
    }
}
