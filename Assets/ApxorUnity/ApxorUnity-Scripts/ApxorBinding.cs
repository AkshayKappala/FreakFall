using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Apxor {
  public class ApxorBinding : MonoBehaviour {

#if UNITY_ANDROID
	private static AndroidJavaObject unityActivity;
	private static AndroidJavaObject apxor;
	private static AndroidJavaObject ApxorClass;
  
    void Start() {
        Debug.Log("Start: Apxor binding for Android.");
    }

	#region Properties
    public static AndroidJavaObject unityCurrentActivity {
        get {
            if (unityActivity == null) {
                using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
                    unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                }
            }
            return unityActivity;
        }
    }

	public static AndroidJavaObject ApxorAPI {
		get {
				if (apxor == null) {
					apxor = Apxor.CallStatic<AndroidJavaObject>("getInstance");
			}
			return apxor;
		}
	}

	public static AndroidJavaObject Apxor {
        get {
            	if (ApxorClass == null) {
					ApxorClass = new AndroidJavaClass("com.apxor.apxorunityplugin.ApxorUnityPlugin");
            }
            return ApxorClass;
        }
	}
	#endregion

    public static void Initialize(string appID) {
		Debug.Log("Start: Apxor Calling Initialize.");
		AndroidJavaObject context = unityCurrentActivity.Call<AndroidJavaObject>("getApplicationContext");
		ApxorAPI.Call("initialize", appID, context);
    }
    
    public static void LogAppEvent(string eventName) {
		ApxorAPI.Call("logAppEvent", eventName, null);
    }
    
    public static void LogAppEvent(string eventName, Dictionary<string, string> properties) {
		ApxorAPI.Call("logAppEvent", eventName, DictionaryToString(properties));
	}

	public static void ReportCustomError(string key, Dictionary<string, string> errorInfo) {
		ApxorAPI.Call("reportCustomError", key, DictionaryToString(errorInfo));
	}
 
	public static void ReportCustomError(string key) {
		ApxorAPI.Call("reportCustomError", key);
	}

	public static void SetUserIdentifier(string id) {
		ApxorAPI.Call("setUserIdentifier", id);
	}

	public static void SetUserCustomInfo(Dictionary<string, string> userInfo) {
		ApxorAPI.Call("setUserCustomInfo", DictionaryToString(userInfo));
	}

	public static void SetCurrentViewName(string viewName) {
		ApxorAPI.Call("setCurrentViewName", viewName);
	}

	public static void SetUserAcquisitionSource(string source) {
		ApxorAPI.Call("setUserAcquisitionSource", source);
	}

	public static string DictionaryToString(Dictionary<string, string> dictionary) {
		if (dictionary != null && dictionary.Count > 0) {
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			foreach (KeyValuePair<string, string> entry in dictionary) {
				stringBuilder.Append(String.Format("{0}={1},", entry.Key, entry.Value));
			}
			if (stringBuilder.Length > 1) {
				stringBuilder.Length--;
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		} else {
			return "";
		}
	}

#else

	// Empty implementations of the API, in case the application is being compiled for a platform other than iOS or Android.
	void Start() {
        Debug.Log("Start: no-op Apxor binding for non iOS/Android.");
    }

    public static void Apxor(string eventName) {
    }

	public static void LogAppEvent(string eventName) {
	}

	public static void LogAppEvent(string eventName, Dictionary<string, object> properties) {
	}

	public static void ReportCustomError(string key, Dictionary<string, string> errorInfo) {
	}
 
	public static void ReportCustomError(string key) {
	}

	public static void SetUserIdentifier(string id) {
	}

	public static void SetUserCustomInfo(Dictionary<string, string> userInfo) {
	}

	public static void SetCurrentViewName(string viewName) {
	}

	public static void SetUserAcquisitionSource(string source) {
	}

#endif
  }
}
