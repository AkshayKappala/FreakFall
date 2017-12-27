using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacheClearer : MonoBehaviour {

	void Start ()
    {
        PlayerPrefs.DeleteAll();
	}
}
