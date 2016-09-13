using UnityEngine;
using System.Collections;

public class LegMovement : MonoBehaviour {


	public GameObject rightKnee;
	private GroundCheck rightKneeGroundCheck;
	public GameObject leftKnee;
	private GroundCheck leftKneeGroundCheck;
	private GroundCheck activeGroundCheck;
	Rigidbody rightKneeRigidbody;
	Rigidbody leftKneeRigidbody;

	private GameObject swingingKnee;
	private Rigidbody swingingKneeRigidbody;
	private GameObject nonSwingingKnee;
	private Rigidbody nonSwingingKneeRigidbody;

	private bool rightKneeSwinging;

	Vector2 joystickInput;
	public float swingPower;

	Vector3 kneeDistanceVector;

	BoxCollider lowerBodyBoxCollider;
	Vector3 lowerBodyBoxColliderOriginalSize;

	float downwardsLegPushThreshhold = 0.8f;



	// Use this for initialization
	void Start () {
		rightKneeRigidbody = rightKnee.GetComponent<Rigidbody> ();
		rightKneeGroundCheck = rightKnee.GetComponent<GroundCheck> ();
		leftKneeRigidbody = leftKnee.GetComponent<Rigidbody> ();
		leftKneeGroundCheck = leftKnee.GetComponent<GroundCheck> ();
		swingingKnee = leftKnee;
		nonSwingingKnee = rightKnee;
		swingingKneeRigidbody = leftKneeRigidbody;
		activeGroundCheck = leftKneeGroundCheck;
		nonSwingingKneeRigidbody = rightKneeRigidbody;
		kneeDistanceVector = swingingKnee.transform.position - nonSwingingKnee.transform.position;

		lowerBodyBoxCollider = GetComponent<BoxCollider> ();
		lowerBodyBoxColliderOriginalSize = lowerBodyBoxCollider.size;

	}



	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		UpdateDownwardsLegPushThreshhold ();
		CheckConditions ();
		AddForce ();
		SwitchLegs ();
		kneeDistanceVector = swingingKnee.transform.position - nonSwingingKnee.transform.position;
		HandleLowerBodyBoxCollider ();

		UpdateDownwardsLegPushThreshhold ();
	}

	private void GetJoystickInput() {
		joystickInput = InputManager.GetLeftStickInput ();
	}

	private void CheckConditions() {
		//Calls statemachine
	}
		

	// STATEMANAGEMENT METHODS

	private void SwapSwingingKnee() {
		if (rightKneeSwinging) {
			swingingKnee = leftKnee;
			swingingKneeRigidbody = leftKneeRigidbody;
			nonSwingingKnee = rightKnee;
			nonSwingingKneeRigidbody = rightKneeRigidbody;
			activeGroundCheck = leftKneeGroundCheck;
			rightKneeSwinging = false;
		} else {
			swingingKnee = rightKnee;
			swingingKneeRigidbody = rightKneeRigidbody;
			nonSwingingKnee = leftKnee;
			nonSwingingKneeRigidbody = leftKneeRigidbody;
			activeGroundCheck = rightKneeGroundCheck;
			rightKneeSwinging = true;
		}
	} 

	private void SwapJoints() {
		Component.Destroy (nonSwingingKnee.GetComponent<SpringJoint> ());
		SpringJoint currentJoint = swingingKnee.AddComponent<SpringJoint> ();
		currentJoint.spring = 5000;
		currentJoint.connectedBody = activeGroundCheck.GetCurrentGround ().GetComponent<Rigidbody>();
		currentJoint.anchor = new Vector3 (-1.35f, 0, 0);
		currentJoint.autoConfigureConnectedAnchor = false;
		currentJoint.connectedAnchor = new Vector3 (currentJoint.connectedAnchor.x, 0.5f, currentJoint.connectedAnchor.z);
	}

	void Swap() {
		
	}

	private void SwitchLegs() {
		if (StepPhase () > downwardsLegPushThreshhold) {
			swingingKneeRigidbody.AddForce (new Vector3(joystickInput.x, -20, joystickInput.y) * 100);
			if (activeGroundCheck.IsGrounded ()) {
				
				SwapJoints ();
				SwapSwingingKnee ();
			}
		}
	}
		


	// GROUNDED METHODS



	private void AddForce() {
		swingingKneeRigidbody.AddForce (joystickInput * swingPower);
	}


	// UTILITIES

	private float StepPhase() {
		float dotProduct = kneeDistanceVector.x * joystickInput.x + kneeDistanceVector.z * joystickInput.y;
		return dotProduct / joystickInput.magnitude;
	}

	private void HandleLowerBodyBoxCollider() {
		if (kneeDistanceVector.magnitude > 0.8f) {
			lowerBodyBoxCollider.size = lowerBodyBoxColliderOriginalSize - new Vector3 (0, 0, kneeDistanceVector.magnitude * 0.35f);
		}

	}

	private void UpdateDownwardsLegPushThreshhold() {
//		float dotProduct = transform.localRotation.eulerAngles.x * joystickInput.x + transform.localRotation.eulerAngles.z * joystickInput.y;
//		return dotProduct / joystickInput.magnitude;
		//print (Mathf.Cos(transform.rotation.eulerAngles.z / 360 * Mathf.PI * 2));
		//print ();



	}
}
