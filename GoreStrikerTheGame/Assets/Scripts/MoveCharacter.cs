using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	Vector2 joystickInput;
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
		AddMovementForce ();
	}

	void GetJoystickInput() {
		joystickInput = InputManager.GetLeftStickInput ();
	}

	void AddMovementForce() {
		movementVector = new Vector3 (joystickInput.x, 0, joystickInput.y);
		rb.AddForce (movementVector * forceMultiplier);
	}
}
