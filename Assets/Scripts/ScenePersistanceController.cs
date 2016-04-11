using UnityEngine;
using System.Collections;

public class ScenePersistanceController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad(gameObject);
	}
}
