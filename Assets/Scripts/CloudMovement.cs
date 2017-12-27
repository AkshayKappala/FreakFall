using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    private void Start()
    {
        this.gameObject.transform.SetParent(GameObject.Find("BackgroundImage").transform);
    }

    void FixedUpdate () {
        this.transform.Translate(Vector2.up * Time.deltaTime * 5);
	}
}
