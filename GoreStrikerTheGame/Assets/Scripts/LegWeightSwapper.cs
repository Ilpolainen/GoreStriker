using UnityEngine;
using System.Collections;

public class LegWeightSwapper : MonoBehaviour {

	float spentWaitTime;
	float maxWaitTime;

	bool legSwitch;

	public GameObject rightKnee;
	public GameObject leftKnee;

	ConstantForce rightKneeForce;
	ConstantForce leftKneeForce;

	public GameObject rightLegWeight;
	public GameObject leftLegWeight;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		spentWaitTime = 0;
		maxWaitTime = 0;

		rb = GetComponent<Rigidbody> ();

		rightKneeForce = rightKnee.GetComponent<ConstantForce> ();
		leftKneeForce = leftKnee.GetComponent<ConstantForce> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (rb.velocity.magnitude < 1) {
			maxWaitTime = 600;
		} else if (rb.velocity.magnitude < 2) {
			maxWaitTime = 200;
		} else if (rb.velocity.magnitude < 4) {
			maxWaitTime = 100;
		} else if (rb.velocity.magnitude < 6) {
			maxWaitTime = 60;
		} else {
			maxWaitTime = 40;
		}

		spentWaitTime++;

		if (spentWaitTime > maxWaitTime) {
			spentWaitTime = 0;

			if (legSwitch) {
				legSwitch = false;
				rightLegWeight.SetActive (true);
				leftLegWeight.SetActive (false);
			} else {
				legSwitch = true;
				rightLegWeight.SetActive (false);
				leftLegWeight.SetActive (true);
			}
		}
	}
}
