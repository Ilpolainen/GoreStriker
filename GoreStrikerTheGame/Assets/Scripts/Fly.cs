using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	ConstantForce cf;
	// Use this for initialization
	void Start () {
		cf = GetComponent<ConstantForce> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("Fire")) {
			cf.force = new Vector3 (0,650,0);
			print ("fly");
		} else {
			cf.force = new Vector3 (0,200,0);
		}
	}
}
