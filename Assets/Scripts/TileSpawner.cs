using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public int themenumber;
    [HideInInspector]
    public GameObject tempChar;
    private float YCoordinate = 21.13f;
    private void Awake()
    {
        themenumber = GameController.theme;
    }

    private float positionselection, x,colorselection;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 13)
        {
            positionselection = Random.Range(1, 6);
            if (positionselection >= 1 && positionselection < 2)
                x = -3.4f;
            else if (positionselection >= 2 && positionselection < 3)
                x = -1.7f;
            else if (positionselection >= 3 && positionselection < 4)
                x = 0;
            else if (positionselection >= 4 && positionselection < 5)
                x = 1.7f;
            else
                x = 3.4f;

            colorselection = Random.Range(10, 202);
            if (colorselection >= 10 && colorselection < 20)
                tempChar = Instantiate(Resources.Load(themenumber + "RescueCharRed"),  new Vector3(x,YCoordinate, 0), Quaternion.identity) as GameObject;
            else if (colorselection >= 20 && colorselection < 80)
                tempChar = Instantiate(Resources.Load(themenumber + "RescueCharGreen"), new Vector3(x, YCoordinate, 0), Quaternion.identity) as GameObject;
            else if (colorselection >= 80 && colorselection < 110)
                tempChar = Instantiate(Resources.Load(themenumber + "RescueCharBlue"), new Vector3(x, YCoordinate, 0), Quaternion.identity) as GameObject;
            else if (colorselection >= 110 && colorselection < 140)
                tempChar = Instantiate(Resources.Load(themenumber + "SurpriseChar"), new Vector3(x, YCoordinate, 0), Quaternion.identity) as GameObject;
            else if (colorselection >= 140 && colorselection < 143)
                tempChar = Instantiate(Resources.Load(themenumber + "Gift"), new Vector3(x, YCoordinate, 0), Quaternion.identity) as GameObject;
            else
                tempChar = Instantiate(Resources.Load(themenumber + "RescueCharGreenF"),  new Vector3(x, YCoordinate, 0), Quaternion.identity) as GameObject;
            other.gameObject.layer = 13;
        }
    }
}
