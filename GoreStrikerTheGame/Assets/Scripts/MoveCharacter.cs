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
	Vector3 evasionVector;

	bool evasionInProgress;
	float evasionDuration = 0.3f;
	float evasionDurationPassed = 0;

	Rigidbody rb;
	public float movementForceMultiplier;
	public float evasionForceMultiplier;

	public GameObject crosshair;
	private MoveCrosshair crosshairMovement;

	string playerName;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		crosshairMovement = crosshair.GetComponent<MoveCrosshair> ();

		if (gameObject.tag == "Player1") {
			playerName = "P1";
		} else if (gameObject.tag == "Player2") {
			playerName = "P2";
		} else if (gameObject.tag == "Player3") {
			playerName = "P3";
		} else if (gameObject.tag == "Player4") {
			playerName = "P4";
		}
	}

	void Update () {
		GetJoystickInput ();
	}
		
	void FixedUpdate() {
		CalculateCompensation ();
		EvasiveStep ();
		DetermineMovementVector ();
		AddMovementForce ();
	}

	void GetJoystickInput() {
		leftJoystickInput = InputManager.GetLeftStickInput (playerName);
		crossHairLocation = crosshairMovement.GetCrosshairLocation ();
	}

	void CalculateCompensation() {
		//differenceInInputs = (leftJoystickInput - crossHairLocation).magnitude;
		//compensation = 1 + differenceInInputs * 0.5f;
		compensationVector = new Vector3(-crossHairLocation.x, 0 , -crossHairLocation.y);

	}

	void EvasiveStep() {
		if (!evasionInProgress && InputManager.GetLeftStickButtonInput (playerName)) {
			evasionInProgress = true;
			evasionVector = (transform.up + new Vector3(0,0.5f,0)) * 10;
		} 

		if (evasionInProgress) {
			evasionDurationPassed = evasionDurationPassed + Time.deltaTime;

			if (evasionDurationPassed > evasionDuration) {
				evasionDurationPassed = 0;
				evasionInProgress = false;
			}
		}
	}

	void DetermineMovementVector() {
		if (evasionInProgress) {
			movementVector = evasionVector;
		} else {
			movementVector = new Vector3 (leftJoystickInput.x, 0, leftJoystickInput.y);
		}
	}

	void AddMovementForce() {
		rb.AddForce (compensationVector * 200);
		if (rb.velocity.magnitude < topSpeed) {
			//rb.AddForce (movementVector * forceMultiplier * compensation);
			rb.AddForce(movementVector * movementForceMultiplier);
		}

	}

}
