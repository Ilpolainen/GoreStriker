using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	bool switcher;
	bool switcher2;
	bool switcher3;
	int counter = 0;
	Rigidbody rb;
	public GameObject leftLeg;
	ConstantForce cfLeft;
	public GameObject rightLeg;
	ConstantForce cfRight;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		cfLeft = leftLeg.GetComponent<ConstantForce> ();
		cfRight = rightLeg.GetComponent<ConstantForce> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w")) {
			rb.AddForce(Vector3.forward * 100 + Vector3.up *10);
		}
			
		counter++;


		if (switcher) {
			cfLeft.force = new Vector3 (0, 200, 0);
			cfRight.force = Vector3.zero;
			print ("left");
		} else if (switcher2) {
			cfLeft.force = Vector3.zero;
			cfRight.force = Vector3.zero;
		} else if (switcher3) {
			cfRight.force = new Vector3 (0, 200, 0);
			cfLeft.force = Vector3.zero;
			print ("right");
		} else {
			cfLeft.force = Vector3.zero;
			cfRight.force = Vector3.zero;
		}

		if (counter > 30) {
			counter = 0;
			if (switcher) {
				switcher = false;
			} else if (switcher2) {
				switcher2 = false;
			} else if (switcher3) {
				switcher3 = false;
			} else {
				switcher = true;
				switcher2 = true;
				switcher3 = true;
			}
		}
	}
}
