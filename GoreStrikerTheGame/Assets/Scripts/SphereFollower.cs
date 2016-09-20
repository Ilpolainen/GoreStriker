using UnityEngine;
using System.Collections;

public class SphereFollower : MonoBehaviour {

	public GameObject leftElbow;
	public GameObject rightElbow;
	private Rigidbody leftElbowRigidbody;
	private Rigidbody rightElbowRigidbody;

	public float thrust;
	private float originalThrust;
	public GameObject target;
	private Vector3 targetLocation;
	private Transform targetPos;

	private Vector3 deadzoneHelper;
	private Vector3 newTarget;

	bool powerThrustGoing;
	float powerThrustDuration = 0.3f;
	float powerThrustDurationPassed = 0;

	bool powerThrustReady;
	float powerThrustCooldown = 3f;
	float powerThrustCooldownPassed = 0;

	public float powerThrustMaximumMultiplier;

	string playerName;

	// Use this for initialization
	void Start () {
		leftElbowRigidbody = leftElbow.GetComponent<Rigidbody> ();
		rightElbowRigidbody = rightElbow.GetComponent<Rigidbody> ();
		targetPos = target.transform;

		originalThrust = thrust;

		if (gameObject.tag == "Player1") {
			playerName = "P1";
		} else if (gameObject.tag == "Player2") {
			playerName = "P2";
		} else if (gameObject.tag == "Player3") {
			playerName = "P3";
		} else if (gameObject.tag == "Player4") {
			playerName = "P4";
		}

		powerThrustReady = true;
	}

	void Update() {
		GetTarget ();
		ApplyDeadzone ();
		CheckPowerThrust ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		AddForceToElbows ();
		//AlternativeAddForceToElbows ();
	}

	void GetTarget() {
		if (!powerThrustGoing) {
			targetLocation = target.transform.position;
		}
	}

	void AddForceToElbows() {
		leftElbowRigidbody.AddForce (thrust * (targetLocation - leftElbow.transform.position));
		rightElbowRigidbody.AddForce (thrust * (targetLocation - rightElbow.transform.position));
	}

	void AlternativeAddForceToElbows() {
		if (leftElbowRigidbody.velocity.magnitude < 12) {
			leftElbowRigidbody.AddForce (thrust * (targetLocation - leftElbow.transform.position));
		} else {
			leftElbowRigidbody.AddForce (thrust / 4 * (targetLocation - leftElbow.transform.position));
		}

		if (rightElbowRigidbody.velocity.magnitude < 12) {
			rightElbowRigidbody.AddForce (thrust * (targetLocation - rightElbow.transform.position));
		} else {
			rightElbowRigidbody.AddForce (thrust / 4 * (targetLocation - rightElbow.transform.position));
		}
	}

	//vielä ihan kesken :)
	void ApplyDeadzone() {
		deadzoneHelper = transform.InverseTransformPoint (targetLocation);
//		print (deadzoneHelper);

		if (deadzoneHelper.y < 2.5f) {

		}

	}

	void CheckPowerThrust() {
		if (InputManager.GetLeftShoulderButtonInput (playerName) && powerThrustGoing == false) {
			powerThrustGoing = true;
			thrust = originalThrust * powerThrustMaximumMultiplier * powerThrustCooldownPassed/powerThrustCooldown;
//			print (playerName + "POWERTHRUST started with multiplier: " + powerThrustMaximumMultiplier * powerThrustCooldownPassed/powerThrustCooldown);
			powerThrustCooldownPassed = 0;
		}

		if (powerThrustGoing) {
			powerThrustDurationPassed = powerThrustDurationPassed + Time.deltaTime;
			if (powerThrustDurationPassed > powerThrustDuration) {
				powerThrustGoing = false;
				powerThrustDurationPassed = 0;
				thrust = originalThrust;
//				print ("POWERTHRUST ended");
			}
		}

		if (powerThrustCooldownPassed < powerThrustCooldown) {
			powerThrustCooldownPassed = powerThrustCooldownPassed + Time.deltaTime;
		}
	}
}
