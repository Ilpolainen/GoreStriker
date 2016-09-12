using UnityEngine;
using System.Collections;

public class LegMovement : MonoBehaviour {


	public GameObject rightKnee;
	public GameObject leftKnee;
	Rigidbody rightKneeRigidbody;
	Rigidbody leftKneeRigidbody;

	private GameObject swingingKnee;
	private Rigidbody swingingKneeRigidbody;

	private bool rightKneeGrounded;

	Vector2 joystickInput;
	public float swingPower;



	// Use this for initialization
	void Start () {
		rightKneeRigidbody = rightKnee.GetComponent<Rigidbody> ();
		leftKneeRigidbody = leftKnee.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		CheckConditions ();
		AddForce ();
	}

	void GetJoystickInput() {
		joystickInput = InputManager.GetLeftStickInput ();
	}

	void CheckConditions() {
		//Calls statemachine
	}
		

	void AddForce() {
		swingingKneeRigidbody.AddForce (joystickInput * swingPower);
	}

	public void SwapSwingingKnee() {
		if (!rightKneeGrounded) {
			swingingKnee = rightKnee;
			swingingKneeRigidbody = rightKneeRigidbody;
			rightKneeGrounded = true;
		} else {
			swingingKnee = leftKnee;
			swingingKneeRigidbody = swingingKneeRigidbody;
			rightKneeGrounded = false;
		}
	} 

	void SwapKneeGroundJoint() {
		
	}


}
