using UnityEngine;
using System.Collections;

public class lastOneIPromise : MonoBehaviour {

    public NameHolder nh;
    public string s;

	// Use this for initialization
	void Start () {
        nh = new NameHolder();
	}

    void Update()
    {
        s = nh.getName();
    }
	
	
}
