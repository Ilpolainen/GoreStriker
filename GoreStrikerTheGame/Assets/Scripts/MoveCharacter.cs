using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	Vector2 leftJoystickInput;
	Vector2 rightJoystickInput;
	float differenceInInputs;
	float compensation;

	Vector3 movementVector;
	Rigidbody rb;
	public float forceMultiplier;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		CalculateCompensation ();
		AddMovementForce ();
	}

	void GetJoystickInput() {
		leftJoystickInput = InputManager.GetLeftStickInput ();
		rightJoystickInput = InputManager.GetRightStickInput ();
	}

	void CalculateCompensation() {
		differenceInInputs = (leftJoystickInput - rightJoystickInput).magnitude;

		compensation = 1 + differenceInInputs * 0.5f;
	}

	void AddMovementForce() {
		movementVector = new Vector3 (leftJoystickInput.x, 0, leftJoystickInput.y);
		rb.AddForce (movementVector * forceMultiplier * compensation);
		print (rb.velocity.magnitude);
	}
}
