using UnityEngine;
using System.Collections;

public class FloorCanvasController : MonoBehaviour {

	CardboardHead head = null;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}

	// Update is called once per frame
	void Update () {
		transform.eulerAngles =  new Vector3 (transform.eulerAngles.x, head.transform.eulerAngles.y, transform.eulerAngles.z);
	}
}
