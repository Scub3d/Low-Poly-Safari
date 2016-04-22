using UnityEngine;
using System.Collections;

public class PictureHolderController : MonoBehaviour {

	public bool setupOccurred = false;
    public TextMesh sb;
	void Update () {
		if(Application.loadedLevelName == "PictureAnalysis" && !setupOccurred) 
			setupPictures();
	}
	
	public void setupPictures() {
		setupOccurred = true;
		transform.position = new Vector3(0, 2.2f, 3f);

	}
    

    public void changeSBtext()
    {
        sb.text = "Upload Photo";
    }

    public void donothing()
    {

    }

}
