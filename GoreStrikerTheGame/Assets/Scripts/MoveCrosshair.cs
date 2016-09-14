﻿using UnityEngine;
using System.Collections;

public class MoveCrosshair : MonoBehaviour {

	public GameObject characterCenter;
	Transform characterCenterPosition;
	Vector2 joystickInput;
	Vector3 newPosition;
	Vector3 previousInput;

	float height;

	public GameObject parentArmature;
	string playerName;

	// Use this for initialization
	void Start () {
		characterCenterPosition = characterCenter.transform;
		if (parentArmature.gameObject.tag == "Player1") {
			playerName = "P1";
		} else if (parentArmature.gameObject.tag == "Player2") {
			playerName = "P2";
		} else if (parentArmature.gameObject.tag == "Player3") {
			playerName = "P3";
		} else if (parentArmature.gameObject.tag == "Player4") {
			playerName = "P4";
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetJoystickInput ();
		GetHeightInput ();
		UpdateCrosshairLocation();
		previousInput = joystickInput;
	}

	void GetJoystickInput() {
		joystickInput = InputManager.GetRightStickInput (playerName);
		if (joystickInput.magnitude < 0.5f) {
			joystickInput = previousInput;
		}
	}

	void GetHeightInput() {
		if (InputManager.GetRightShoulderButtonInput (playerName)) {
			height = 6;
		} else if (InputManager.GetRightTriggerInput (playerName)) {
			height = -4;
		} else {
			height = 3;
		}
	}

	public Vector2 GetCrosshairLocation() {
		return joystickInput;
	}

	void UpdateCrosshairLocation() {
		newPosition = characterCenterPosition.position + new Vector3 (joystickInput.x, 0, joystickInput.y).normalized * 4;
		newPosition.y = height;

		transform.position = newPosition;
	}


}
