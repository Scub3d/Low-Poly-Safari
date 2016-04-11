using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {

	public int pictureScore;

	public bool isPassive;

	public bool isIdle = true;

	public PlayerController playerController;
	public TakePicture takePicture;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetGazedAt(bool gazedAt) {
		takePicture.animalInShot = gazedAt;
		takePicture.animalName = gazedAt ? name : null;
	}
}
