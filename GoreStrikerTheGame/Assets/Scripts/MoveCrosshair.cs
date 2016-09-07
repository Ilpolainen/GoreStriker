using UnityEngine;
using System.Collections;

public class MoveCrosshair : MonoBehaviour {

	public GameObject characterCenter;
	Transform characterCenterPosition;
	Vector2 joystickInput;

	// Use this for initialization
	void Start () {
		characterCenterPosition = characterCenter.transform;
	}
	
	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		UpdateCrosshairLocation();
	}

	void GetJoystickInput() {
		joystickInput = InputManager.GetRightStickInput ();
	}

	void UpdateCrosshairLocation() {
		transform.position = characterCenterPosition.position + new Vector3 (joystickInput.x, 0, joystickInput.y).normalized * 3;
	}


}
