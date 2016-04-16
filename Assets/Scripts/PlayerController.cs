using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public string lookingAt;

	public bool cameraSelected = true;
	
	public int points = 0;

	public bool canShootDart = true;

	public UnityEngine.UI.Text switchWeaponText;
	public UnityEngine.UI.Text switchDayAndNightText;


	public DartController dartController;
	public TakePicture takePicture;
	
	public bool isOnSafari = true;

	public TextMesh d;

	void Start() {


	}

	// Update is called once per frame
	void Update () {

		isOnSafari = Application.loadedLevelName.Equals("PictureAnalysis") ? false : true;
		d.text = cameraSelected.ToString();

		if(!isOnSafari)
			pictureAnalysisSetup();

		if(Input.GetButtonUp("Fire1")) {
			if(cameraSelected && isOnSafari)
				takePicture.takePicture();
			else if(canShootDart && isOnSafari)
				dartController.createProjectile();
			else if(1==1)
				Debug.Log("as");
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
	}
}
