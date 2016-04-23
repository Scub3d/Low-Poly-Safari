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

	public UnityEngine.UI.Text filmUsedText;
    public UnityEngine.UI.Text scoreText;

    public SendPictureToServer spts;

    public UnityEngine.UI.Image flash;

    public void takePicture() {
		if(unlocked && animalInShot && filmUsed < pictureFrames.Length - 1) {
			
			StartCoroutine(TakeSnapshot(Screen.width,Screen.height));

            GameObject animal = GameObject.Find(animalName);

            float distance = Vector3.Distance(animal.transform.position, player.transform.position);
            Debug.Log(distance);

            // apply points

            float multiplier = 1f;

            if (distance > 16f && distance < 30f)
                multiplier = .5f;
            else if (distance >= 30f)
                multiplier = .2f;

            playerController.points += animal.GetComponent<AnimalController>().pictureScore * multiplier;

            scoreText.text = "Score: " + playerController.points.ToString() + " Points";

            filmUsed++;
            updateFilmText();
            StartCoroutine(Wait());
		}

		if(filmUsed >= pictureFrames.Length - 1)
			StartCoroutine(EndScene());

	}

    public void updateFilmText()
    {
        filmUsedText.text = "Photos remaining: " + (9 - filmUsed).ToString();
    }

    public void ruinFilm()
    {
        pictureFrames[filmUsed].tag = "ruined";
    }

	IEnumerator Wait()	{
		unlocked = false;
		yield return new WaitForSeconds(.5f);
		unlocked = true;
	}

	IEnumerator EndScene() {
		yield return new WaitForSeconds(.3f);
		Application.LoadLevel("PictureAnalysis");
	}


    IEnumerator Flash()
    {
        flash.enabled = true;
        yield return new WaitForSeconds(.1f);
        flash.enabled = false;
    }


    IEnumerator TakeSnapshot(int width, int height) { 
		yield return new WaitForEndOfFrame();

		Texture2D texture = new Texture2D (width / 2, height, TextureFormat.RGB24, true); 
		texture.ReadPixels(new Rect(0, 0, width / 2, height), 0, 0);

		texture.Apply(); 
		pictureFrames[filmUsed].GetComponent<Renderer>().material.mainTexture = texture;
        StartCoroutine(Flash());

    }




}
