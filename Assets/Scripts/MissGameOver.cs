using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissGameOver : MonoBehaviour {
    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Time.timeScale ==1)
        {
            if (Physics.Raycast(ray, out hit))
                if (hit.collider.gameObject.CompareTag("Miss"))
                {
                    UIManager.Instance.ShowGameOverMenu();
                }
        }
    }
}
