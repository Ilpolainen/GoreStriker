using UnityEngine;
using System.Collections;

public class BodyCounterForce : MonoBehaviour {

	ConstantForce cf;
	// Use this for initialization
	void Start () {
		cf = GetComponent<ConstantForce> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cf.relativeTorque = new Vector3 (0, 1000 * transform.rotation.y, 0);
	}
}
