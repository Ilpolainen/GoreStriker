using UnityEngine;
using System.Collections;

public class WeaponHitEmpower : MonoBehaviour {

	public float extraPowerMultiplier;
	Rigidbody weaponRigidbody;

	int cooldownPassed;
	int cooldown = 30;

	bool weaponMadeContact;

	Rigidbody victimRigidbody;
	Vector3 empoweredHitVector;
	int forceCooldownPassed;
	int forceCooldown = 5;

	// Use this for initialization
	void Start () {
		weaponRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownPassed++;
		forceCooldownPassed++;
	}

	void FixedUpdate() {
		if (weaponMadeContact) {
			victimRigidbody.AddForce (empoweredHitVector * extraPowerMultiplier);
			print ("Adding BOW POWER");
			if (forceCooldownPassed > forceCooldown) {
				weaponMadeContact = false;
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (gameObject.layer - 1 != col.gameObject.layer && col.gameObject.layer != 16) {
			if (cooldownPassed > cooldown) {
				victimRigidbody = col.gameObject.GetComponent<Rigidbody> ();
				forceCooldownPassed = 0;
				weaponMadeContact = true;
				if (col.gameObject.tag != "Weapon") {
					empoweredHitVector = weaponRigidbody.velocity * extraPowerMultiplier;
				} else {
					empoweredHitVector = weaponRigidbody.velocity * extraPowerMultiplier * 0.5f;
				}
			}
			cooldownPassed = 0;

		}

//		if (gameObject.layer - 1 != col.gameObject.layer) {
//			print ("Hit something other than myself");
//		}
//
//		if (col.gameObject.layer == 16) {
//			print ("GROUNDSLAM");
//		}
	}
}
