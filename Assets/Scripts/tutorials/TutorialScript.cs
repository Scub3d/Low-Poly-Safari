using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

    public string uname = "Default";
    public bool tapped = false;

    public bool askingForName = true;
    public bool tutorialing = false;
    public bool takePicsLesson = false;
    public bool lastLession = false;

    public GameObject KeyboardTextThing;
    public GameObject WalkingTextHolder;
    public GameObject testAnimsHolder;
    public GameObject takePicTextHolder;
    public GameObject miscTextHolder;

    public Transform p;
    private Vector3 startPos = new Vector3(0, 0, 0);

    public TouchScreenKeyboard keyboard;

    public bool looker = false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(askingForName)
        {
            if (!tapped)
            {
                if (Cardboard.SDK.Triggered)
                {
                    keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, false);
                    tapped = true;
                }
            }
            else {
                if (keyboard != null && keyboard.done)
                {
                    GameObject.Find("NameHolder").GetComponent<lastOneIPromise>().nh.setName(keyboard.text);
                    transitionToTut();
                }
            }
        } else if(tutorialing)
        {
            if(!takePicsLesson)
            {
                if (Vector3.Distance(new Vector3(p.position.x, 0, p.position.z), startPos) > 6f)
                {
                    doMoreTuts();
                }
            } else
            {
                if(looker && Cardboard.SDK.Triggered)
                {
                    moveToLastLesson();
                }
            }
            
        }


        if (KeyboardTextThing != null)
        {
            KeyboardTextThing.transform.position = new Vector3(p.position.x, 0, p.position.z);
        }
        else if (WalkingTextHolder != null)
        {
            WalkingTextHolder.transform.position = new Vector3(p.position.x, 0, p.position.z);
        }
        else if (takePicTextHolder != null)
        {
            takePicTextHolder.transform.position = new Vector3(p.position.x, 0, p.position.z);
        }
        else if (miscTextHolder != null)
        {
            miscTextHolder.transform.position = new Vector3(p.position.x, 0, p.position.z);
        }

    }

    public void transitionToTut()
    {
        tutorialing = true;
        askingForName = false;
        KeyboardTextThing.active = false;
        KeyboardTextThing = null;
        testAnimsHolder.transform.position = new Vector3(0, 0, 0);
        WalkingTextHolder.transform.position = new Vector3(0, 0, 0);
    }

    public void doMoreTuts()
    {
        WalkingTextHolder.active = false;
        WalkingTextHolder = null;
        takePicTextHolder.transform.position = Vector3.zero;
        takePicsLesson = true;
    }

    public void lockItDown()
    {
        askingForName = false;
        takePicsLesson = false;
        tutorialing = false;
        lastLession = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        Application.LoadLevel("testScene");

    }

    public void moveToLastLesson()
    {
        lastLession = true;
        looker = false;
        takePicTextHolder.active = false;
        takePicTextHolder = null;
        miscTextHolder.transform.position = Vector3.zero;
    }
    
}
