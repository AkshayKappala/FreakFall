using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using Apxor;

public class ApxorUnity: MonoBehaviour {

	public String APXOR_ANDROID_APP_ID = "YOUR_APXOR_ANDROID_APP_ID";
	public String APXOR_IOS_APP_ID = "YOUR_APXOR_IOS_APP_ID";

	void Awake()
	{
#if (UNITY_IPHONE && !UNITY_EDITOR)
		Debug.Log("Start: Apxor iOS SDK First Step.");
        DontDestroyOnLoad(gameObject);
		ApxorBinding.Initialize(APXOR_IOS_APP_ID);
		Debug.Log("Start: Apxor iOS SDK initialized.");
#endif

#if (UNITY_ANDROID && !UNITY_EDITOR)
		DontDestroyOnLoad(gameObject);
		ApxorBinding.Initialize(APXOR_ANDROID_APP_ID);
#endif
	}
    
    void Start() {
		
	}

}
