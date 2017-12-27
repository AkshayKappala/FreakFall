using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {
    private void Start()
    {

        Destroy(this.gameObject, 5);
    }

    void Update ()
    {
        transform.Translate(Vector2.left*Time.deltaTime*10);
	}
}
