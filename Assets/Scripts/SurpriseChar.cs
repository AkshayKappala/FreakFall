using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SurpriseChar : MonoBehaviour
{
    public float selector;
    public GameObject GeneratedChar;
    public int themenumber;
    public AudioClip clip;
    public AudioSource AudioSource;
    private void Awake()
    {
        themenumber = GameController.theme;
    }
    public void Start()
    {
        selector = Random.Range(1, 5);
        clip = Resources.Load("ParachuteOpen") as AudioClip;
        AudioSource = (AudioSource)FindObjectOfType<AudioSource>();
        AudioSource.loop = false;
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime *BasicTileScript.StartVelocity);
    }

    private void OnMouseDown()
    {
        AudioSource.PlayOneShot(clip);
        if (!IsPointerOverUIObject())
        {
            if (selector < 3)
            {
                Instantiate(Resources.Load(themenumber + "RescueCharRed"), this.transform.position, Quaternion.identity);

            }
            else
            {
                GeneratedChar = Instantiate(Resources.Load(themenumber + "RescueCharGreen"), this.transform.position, Quaternion.identity) as GameObject;
                GeneratedChar.layer = 13;
            }
            Destroy(this.gameObject);
            Instantiate(Resources.Load("PoofWhite"), this.transform.position, Quaternion.identity);
        }
    }

    //below method is written in substitution to EventSystem.current.IsPointerOverGameObject()
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
