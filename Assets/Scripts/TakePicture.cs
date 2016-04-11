using UnityEngine;
using System.Collections;
using System;



public class TakePicture : MonoBehaviour {

	public bool unlocked = true;

	public GameObject player;
	public PlayerController playerController;
	
	public bool animalInShot;
	public string animalName;
	
	public int resWidth = 1080; 
	public int resHeight = 1080;

	public GameObject[] pictureFrames = new GameObject[10];

	public int filmUsed = -1;

	public void takePicture() {
		if(unlocked && animalInShot && filmUsed < pictureFrames.Length - 1) {
			
			StartCoroutine(TakeSnapshot(Screen.width,Screen.height));

			filmUsed++;
			StartCoroutine(Wait());
		}

		if(filmUsed >= pictureFrames.Length - 1)
			StartCoroutine(EndScene());

	}

	IEnumerator Wait()	{
		unlocked = false;
		yield return new WaitForSeconds(.5f);
		unlocked = true;
	}

	IEnumerator EndScene() {
		yield return new WaitForSeconds(.5f);
		Application.LoadLevel("PictureAnalysis");
	}

	
	IEnumerator TakeSnapshot(int width, int height) { 
		yield return new WaitForEndOfFrame();

		Texture2D texture = new Texture2D (width / 2, height, TextureFormat.RGB24, true); 
		texture.ReadPixels(new Rect(0, 0, width / 2, height), 0, 0);

		texture.Apply(); 
		pictureFrames[filmUsed].GetComponent<Renderer>().material.mainTexture = texture;
	} 


	

}
