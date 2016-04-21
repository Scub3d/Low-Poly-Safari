using UnityEngine;
using System.Collections;

public class DartCollisionController : MonoBehaviour {

	void OnTriggerEnter(Collider col) {

		if(col.gameObject.tag == "Animal") {
			col.GetComponent<AnimalController>().hitWithTranq();
		}
		Destroy(gameObject);

	}
}
