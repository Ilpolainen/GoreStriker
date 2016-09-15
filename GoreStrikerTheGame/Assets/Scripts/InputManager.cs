using UnityEngine;
using System.Collections;

public static class InputManager {

	private static float deadZoneAmount = 0.4f;
	private static Vector2 leftStickInput;
	private static Vector2 rightStickInput;

	public static Vector2 GetLeftStickInput(string playerName) {
		leftStickInput = new Vector2 (Input.GetAxis (playerName + "LHorizontal"), Input.GetAxis (playerName + "LVertical"));
		if (leftStickInput.magnitude < deadZoneAmount) {
			leftStickInput = Vector2.zero;
		} else {
			leftStickInput = leftStickInput.normalized * ((leftStickInput.magnitude - deadZoneAmount) / (1 - deadZoneAmount));
		}

		return leftStickInput;
	}

	public static Vector2 GetRightStickInput(string playerName) {
		rightStickInput = new Vector2 (Input.GetAxis (playerName + "RHorizontal"), Input.GetAxis (playerName + "RVertical"));
		if (rightStickInput.magnitude < deadZoneAmount) {
			rightStickInput = Vector2.zero;
		} else {
			rightStickInput = rightStickInput.normalized * ((rightStickInput.magnitude - deadZoneAmount) / (1 - deadZoneAmount));
		}
			
		return rightStickInput;
	}

	public static bool GetRightShoulderButtonInput(string playerName) {
		if (Input.GetButton (playerName + "RShoulderButton")) {
			return true;
		} else {
			return false;
		}
	}

	public static bool GetRightTriggerInput(string playerName) {
		if (Input.GetAxis (playerName + "RTrigger") > 0.5f) {
			return true;
		} else {
			return false;
		}
	}

	public static bool GetLeftShoulderButtonInput(string playerName) {
		if (Input.GetButton (playerName + "LShoulderButton")) {
			return true;
		} else {
			return false;
		}
	}

	public static bool GetLeftTriggerInput(string playerName) {
		if (Input.GetAxis (playerName + "LTrigger") > 0.5f) {
			return true;
		} else {
			return false;
		}
	}

	public static bool GetLeftStickButtonInput(string playerName) {
		if (Input.GetButtonDown(playerName + "LeftStickButton")) {
			return true;
		} else {
			return false;
		}
	}
}
