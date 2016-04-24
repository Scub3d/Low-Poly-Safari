using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f,-.04f,0f);

        if (transform.position.z > 80f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -80f);
        }
	}
}
