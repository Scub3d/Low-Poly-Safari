using UnityEngine;
using System.Collections;

public class PictureHolderController : MonoBehaviour {

	public bool setupOccurred = false;

	void Update () {
		if(Application.loadedLevelName == "PictureAnalysis" && !setupOccurred) 
			setupPictures();
	}
	
	public void setupPictures() {
		setupOccurred = true;
		transform.position = new Vector3(0, 2.2f, 3f);

	}
}
