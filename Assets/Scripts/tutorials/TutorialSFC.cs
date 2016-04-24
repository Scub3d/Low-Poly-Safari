using UnityEngine;
using System.Collections;

public class TutorialSFC : MonoBehaviour {

    public TutorialScript ts;

	// Use this for initialization
	void Start () {
	
	}

    public void SetGazedAt(bool gazedAt)
    {
        ts.looker = gazedAt;
    }
}
