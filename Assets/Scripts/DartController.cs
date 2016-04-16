using UnityEngine;
using System.Collections;

public class DartController : MonoBehaviour {

	public GameObject projectile;
	public Transform shotPos;
	public float shotForce = 1000f;

	public int tranqDartsLeft = 5;

	public UnityEngine.UI.Text dartsLeftText;

	public void createProjectile() {
		if (tranqDartsLeft > 0) {
			GameObject shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as GameObject;
			shot.transform.forward = -shotPos.right;
			shot.GetComponent<Rigidbody>().AddForce(shotPos.forward * shotForce);
			tranqDartsLeft--;
			dartsLeftText.text = "Tranq Darts Left: " + tranqDartsLeft.ToString();
		}
	}

}
