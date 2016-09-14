using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	Vector2 leftJoystickInput;
	Vector2 crossHairLocation;
	public float topSpeed;
	float differenceInInputs;
	float compensation;
	Vector3 compensationVector;

	Vector3 movementVector;
	Rigidbody rb;
	public float forceMultiplier;

	public GameObject crosshair;
	private MoveCrosshair crosshairMovement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		crosshairMovement = crosshair.GetComponent<MoveCrosshair> ();
	}

	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		CalculateCompensation ();
		AddMovementForce ();
	}

	void GetJoystickInput() {
		leftJoystickInput = InputManager.GetLeftStickInput ();
		crossHairLocation = crosshairMovement.GetCrosshairLocation ();
	}

	void CalculateCompensation() {
		//differenceInInputs = (leftJoystickInput - crossHairLocation).magnitude;
		//compensation = 1 + differenceInInputs * 0.5f;
		compensationVector = new Vector3(-crossHairLocation.x, 0 , -crossHairLocation.y);

	}

	void AddMovementForce() {
		movementVector = new Vector3 (leftJoystickInput.x, 0, leftJoystickInput.y);
		rb.AddForce (compensationVector * 200);
		if (rb.velocity.magnitude < topSpeed) {
			//rb.AddForce (movementVector * forceMultiplier * compensation);
			rb.AddForce(movementVector * forceMultiplier);
		}

	}
}
