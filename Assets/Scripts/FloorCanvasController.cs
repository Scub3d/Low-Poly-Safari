using UnityEngine;
using System.Collections;

public class FloorCanvasController : MonoBehaviour {

	public Transform camera;

	// Update is called once per frame
	void Update () {
		transform.rotation = camera.rotation;
	}
}
