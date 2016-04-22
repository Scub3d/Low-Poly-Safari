using System.Collections;
using UnityEngine;

public class PictureController : MonoBehaviour {

    public bool selected = false;
    public bool isBeingLooked = false;
    public SendPictureToServer spts;
    public Transform highlight;
    public PictureHolderController phc;


	// Use this for initialization
	void Start () {
	
	}

    public void beingLookedAt(bool state)
    {
        isBeingLooked = state;
    }

    public void getSelected ()
    {
        if(gameObject.tag != "ruined")
        {
            selected = true;
            spts.selectedPicture = gameObject;
            highlight.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, .05f);
            phc.changeSBtext();
        }
       
    }


}
