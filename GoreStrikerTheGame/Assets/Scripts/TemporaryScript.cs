using UnityEngine;
using System.Collections;

public class TemporaryScript : MonoBehaviour {

	public Limb head;
	public Limb rightArm;
	public Limb rightElbow;
	public Limb leftArm;
	public Limb leftElbow;
	public Limb rightLeg;
	public Limb rightKnee;
	public Limb leftLeg;
	public Limb leftKnee;

	public GameObject middleSpine;

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		if (Input.GetKeyDown ("q")) {
			head.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("w")) {
			rightArm.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("e")) {
			rightElbow.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("r")) {
			leftArm.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("t")) {
			leftElbow.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("y")) {
			rightLeg.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("u")) {
			rightKnee.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("i")) {
			leftLeg.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}
		if (Input.GetKeyDown ("o")) {
			leftKnee.Cut ();
			middleSpine.GetComponent<ConstantForce> ().force = middleSpine.GetComponent<ConstantForce> ().force / 1.5f;
		}

	}
	
	// Update is called once per frame

}
