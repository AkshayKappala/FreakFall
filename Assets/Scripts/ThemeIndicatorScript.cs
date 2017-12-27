using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeIndicatorScript : MonoBehaviour {
	void Update ()
    {
        if(GameController.theme==1)
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -900);
        else if(GameController.theme==2)
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -900);
        else if(GameController.theme==3)
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -900);

    }
}
