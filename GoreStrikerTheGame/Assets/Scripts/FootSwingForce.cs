using UnityEngine;
using System.Collections;

public class FootSwingForce : MonoBehaviour {

	Vector2 joystickInput;
	Rigidbody rb;
	public float swingPower;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		AddForce ();
	}

	void GetJoystickInput() {
		joystickInput = InputManager.GetLeftStickInput ();
	}

	void AddForce() {
		rb.AddForce (joystickInput * swingPower);
	}
}
