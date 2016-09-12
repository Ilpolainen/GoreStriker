using UnityEngine;
using System.Collections;

public static class InputManager {

	private static float deadZoneAmount = 0.4f;
	private static Vector2 leftStickInput;
	private static Vector2 rightStickInput;

	public static Vector2 GetLeftStickInput() {
		leftStickInput = new Vector2 (Input.GetAxis ("LHorizontal"), Input.GetAxis ("LVertical"));
		if (leftStickInput.magnitude < deadZoneAmount) {
			leftStickInput = Vector2.zero;
		} else {
			leftStickInput = leftStickInput.normalized * ((leftStickInput.magnitude - deadZoneAmount) / (1 - deadZoneAmount));
		}

		return leftStickInput;
	}

	public static Vector2 GetRightStickInput() {
		rightStickInput = new Vector2 (Input.GetAxis ("RHorizontal"), Input.GetAxis ("RVertical"));
		if (rightStickInput.magnitude < deadZoneAmount) {
			rightStickInput = Vector2.zero;
		} else {
			rightStickInput = rightStickInput.normalized * ((rightStickInput.magnitude - deadZoneAmount) / (1 - deadZoneAmount));
		}
			
		return rightStickInput;
	}

	public static bool GetRightShoulderButtonInput() {
		if (Input.GetButton ("RShoulderButton")) {
			return true;
		} else {
			return false;
		}
	}

	public static bool GetRightTriggerInput() {
		if (Input.GetAxis ("RTrigger") > 0.5f) {
			return true;
		} else {
			return false;
		}
	}

	public static bool GetLeftShoulderButtonInput() {
		if (Input.GetButton ("LShoulderButton")) {
			return true;
		} else {
			return false;
		}
	}

	public static bool GetLeftTriggerInput() {
		if (Input.GetAxis ("LTrigger") > 0.5f) {
			return true;
		} else {
			return false;
		}
	}
}
