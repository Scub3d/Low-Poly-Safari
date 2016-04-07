using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public GameObject projectile;
	public Transform shotPos;
	public float shotForce = 1000f;

	void Update() {
		if(Input.GetButtonUp("Fire1"))
			createProjectile();
	}
	
	public void createProjectile() {
		GameObject shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as GameObject;
		shot.transform.forward = -shotPos.right;
		shot.GetComponent<Rigidbody>().AddForce(shotPos.forward * shotForce);
	}

}
