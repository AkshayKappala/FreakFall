using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicTileScript : MonoBehaviour
{
    public static float StartVelocity;
    public float startvelocityref;
    public bool isdestroying = false;
    [HideInInspector]
    public bool isfirsttap=false;
    public TileType Tiletype;
    public AudioClip clip;
    public int themenumber;
    public bool isFirstBlueChute = true;
    public GameObject blueParachute1;
    public AudioSource AudioSource;

    private void Awake()
    {
        themenumber = GameController.theme;

        clip = Resources.Load("ParachuteOpen") as AudioClip;
        AudioSource = (AudioSource)FindObjectOfType<AudioSource>();
        AudioSource.loop = false;
    }
    private void Start()
    {
        StartVelocity = 9;
        startvelocityref = StartVelocity;
        //float position = this.gameObject.transform.position.x;
    }

    void Update ()
    {
        //  StartVelocity =startvelocityref+0.01f* UIManager.Instance.score;
        if(UIManager.Instance.TileSpeed <= 600)
        {
            StartVelocity = startvelocityref + 0.01f * UIManager.Instance.TileSpeed;
            transform.Translate(Vector3.down * Time.deltaTime * StartVelocity);
        }
        else
        {
            StartVelocity = 13;
            transform.Translate(Vector3.down * Time.deltaTime * 13);
        }
      //  Debug.Log(StartVelocity);
	}
    private void FixedUpdate()
    {
        if(isdestroying)
        {
            this.gameObject.transform.localScale /= 1.02f;
        }
    }
    private void OnMouseDown()
    {
        AudioSource.PlayOneShot(clip);
        if (!IsPointerOverUIObject())
        {
            if (Tiletype == TileType.Red)
            {
                Instantiate(Resources.Load("PoofBlack"), this.transform.position, Quaternion.identity);
                UIManager.Instance.ShowGameOverMenu();
                Destroy(this.gameObject);
            }
            else if (Tiletype == TileType.Green)
            {
                greenfunction();
            }
            else if (Tiletype == TileType.Blue)
            {
                bluefunction2();
            }
        }
    }


    void greenfunction()
    {
        isfirsttap = true;
        GameObject parachute = Instantiate(Resources.Load(themenumber + "Parachute"), this.transform.position + new Vector3(0, 1 , 0), Quaternion.identity) as GameObject;
        parachute.transform.SetParent(this.gameObject.transform);
        isdestroying = true;
        Destroy(this.gameObject, 0.3f);
        this.gameObject.layer = 2;
        UIManager.Instance.score++;
        UIManager.Instance.TileSpeed++;
    }
   
    void bluefunction2()
    {
        UIManager.Instance.score++;
        UIManager.Instance.TileSpeed++;
        if (isFirstBlueChute == true)
        {
            blueParachute1 = Instantiate(Resources.Load(themenumber + "BlueParachute1"), this.transform.position, Quaternion.identity) as GameObject;
            blueParachute1.transform.SetParent(this.gameObject.transform);
            blueParachute1.transform.position += new Vector3(0, 1.75f, 0);
            isFirstBlueChute = false;
        }
        else if(isFirstBlueChute == false)
        {
            isfirsttap = true;
            Destroy(blueParachute1);
            GameObject parachute = Instantiate(Resources.Load(themenumber + "BlueParachute2"), this.transform.position, Quaternion.identity) as GameObject;
            parachute.transform.SetParent(this.gameObject.transform);
            parachute.transform.position += new Vector3(0, 1.75f, 0);
            isdestroying = true;
            Destroy(this.gameObject, 0.3f);
            this.gameObject.layer = 2;
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