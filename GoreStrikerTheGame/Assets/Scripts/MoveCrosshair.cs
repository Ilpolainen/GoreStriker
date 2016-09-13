using UnityEngine;
using System.Collections;

public class MoveCrosshair : MonoBehaviour {

	public GameObject characterCenter;
	Transform characterCenterPosition;
	Vector2 joystickInput;
	Vector3 newPosition;
	Vector3 previousInput;

	float height;

	// Use this for initialization
	void Start () {
		characterCenterPosition = characterCenter.transform;
	}
	
	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		GetHeightInput ();
		UpdateCrosshairLocation();
		previousInput = joystickInput;
	}

	void GetJoystickInput() {
		joystickInput = InputManager.GetRightStickInput ();
		if (joystickInput.magnitude < 0.5f) {
			joystickInput = previousInput;
		}
	}

	void GetHeightInput() {
		if (InputManager.GetRightShoulderButtonInput ()) {
			height = 6;
		} else if (InputManager.GetRightTriggerInput ()) {
			height = -4;
		} else {
			height = 3;
		}
	}

	void UpdateCrosshairLocation() {
		newPosition = characterCenterPosition.position + new Vector3 (joystickInput.x, 0, joystickInput.y).normalized * 4;
		newPosition.y = height;

		transform.position = newPosition;
	}


}
