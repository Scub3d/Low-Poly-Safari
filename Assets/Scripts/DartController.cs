using UnityEngine;
using System.Collections;

public class DartController : MonoBehaviour {

    public GameObject dart;
    public Transform dartPos;
    public float shotForce = 1000f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody shot = Instantiate(dart, dartPos.position, dartPos.rotation) as Rigidbody;
        shot.AddForce(dartPos.forward * shotForce);
	}
}
