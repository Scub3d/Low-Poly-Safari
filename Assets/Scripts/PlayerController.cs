using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public string lookingAt;

	public bool cameraSelected = true;
	
	public float points = 0;

	public bool canShootDart = true;

	public UnityEngine.UI.Text switchWeaponText;
	public UnityEngine.UI.Text switchDayAndNightText;


	public DartController dartController;
	public TakePicture takePicture;
	
	public bool isOnSafari = true;
    public bool setup = false;

	// Update is called once per frame
	void Update () {
        if(!setup)
		    isOnSafari = Application.loadedLevelName.Equals("PictureAnalysis") ? false : true;

		if(!isOnSafari && !setup)
			pictureAnalysisSetup();

		if(Cardboard.SDK.Triggered) {
			if(cameraSelected && isOnSafari)
				takePicture.takePicture();
			else if(canShootDart && isOnSafari) {
				dartController.createProjectile();
			} 

		}
			
	}

	public void toggleDartGunLock(bool lockState) {
		canShootDart = lockState;
	}

	public void changeWeapons() {
		switchWeaponText.text = cameraSelected ? "Camera" : "Tranq Gun";
		cameraSelected  = cameraSelected ? false : true;
	}

	public void setLookingAt(string animal) {
		lookingAt = animal;
	}

	public void pictureAnalysisSetup() {
		transform.position = new Vector3(0,0,0);
		transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
		GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        setup = true;
        GetComponent<Autowalk>().enabled = false;
        GameObject.Find("Switch Item Button").active = false;
	}

    public void loseShot()
    {
        takePicture.filmUsed++;
        takePicture.updateFilmText();
        takePicture.ruinFilm();

    }

}
