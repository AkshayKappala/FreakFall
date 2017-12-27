using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour {

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Clouds"))
        {
            Instantiate(Resources.Load("Clouds"), GameObject.Find("BackgroundImage").transform.position + new Vector3(0, -22, 0), Quaternion.identity);
        }
    }
    
}
