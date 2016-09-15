using UnityEngine;
using System.Collections;

public class SphereFollower : MonoBehaviour {

	public float thrust;
	private float originalThrust;
	public GameObject target;
	private Vector3 targetLocation;
	private Transform targetPos;
	private Rigidbody rb;

	bool powerThrustGoing;
	float powerThrustDuration = 0.3f;
	float powerThrustDurationPassed = 0;

	bool powerThrustReady;
	float powerThrustCooldown = 3f;
	float powerThrustCooldownPassed = 0;

	public float powerThrustMaximumMultiplier;

	public GameObject parentArmature;
	string playerName;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		targetPos = target.transform;

		originalThrust = thrust;

		if (parentArmature.gameObject.tag == "Player1") {
			playerName = "P1";
		} else if (parentArmature.gameObject.tag == "Player2") {
			playerName = "P2";
		} else if (parentArmature.gameObject.tag == "Player3") {
			playerName = "P3";
		} else if (parentArmature.gameObject.tag == "Player4") {
			playerName = "P4";
		}

		powerThrustReady = true;
	}

	void Update() {
		GetTarget ();
		CheckPowerThrust ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (thrust * (targetLocation - transform.position));
	}

	void GetTarget() {
		if (!powerThrustGoing) {
			targetLocation = target.transform.position;
		}
	}

	void CheckPowerThrust() {
		if (InputManager.GetLeftShoulderButtonInput (playerName) && powerThrustGoing == false) {
			powerThrustGoing = true;
			thrust = thrust * powerThrustMaximumMultiplier * powerThrustCooldownPassed/powerThrustCooldown;
			print ("POWERTHRUST started with multiplier: " + powerThrustMaximumMultiplier * powerThrustCooldownPassed/powerThrustCooldown);
			powerThrustCooldownPassed = 0;
		}

		if (powerThrustGoing) {
			powerThrustDurationPassed = powerThrustDurationPassed + Time.deltaTime;
			if (powerThrustDurationPassed > powerThrustDuration) {
				powerThrustGoing = false;
				powerThrustDurationPassed = 0;
				thrust = originalThrust;
				print ("POWERTHRUST ended");
			}
		}

		if (powerThrustCooldownPassed < powerThrustCooldown) {
			powerThrustCooldownPassed = powerThrustCooldownPassed + Time.deltaTime;
		}
	}
}
