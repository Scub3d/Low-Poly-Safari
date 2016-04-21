using UnityEngine;
using System.Collections;

public class FallingController : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "Animal") {
			col.transform.position = new Vector3(14.2f, 5f, -4.4f);
		}
	}
}
