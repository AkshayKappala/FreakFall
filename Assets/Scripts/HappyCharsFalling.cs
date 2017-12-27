using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyCharsFalling : MonoBehaviour {
    public float StartVelocity=0.25f;

    public void Start()
    {
        Destroy(this.gameObject, 40);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * StartVelocity);
    }
}
