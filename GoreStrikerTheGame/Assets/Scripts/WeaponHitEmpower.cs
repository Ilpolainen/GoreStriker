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

	ReceiveDamage victimReceiveDamage;
	bool hitConnectedBody;
	bool victimReadyForAnotherDamageBlow;
	string victimsBodypart;
	float damageForce;

	// Use this for initialization
	void Start () {
		weaponRigidbody = GetComponent<Rigidbody> ();
		victimReadyForAnotherDamageBlow = true;
	}
	
	// Update is called once per frame
	void Update () {
		cooldownPassed++;
		forceCooldownPassed++;
	}

	void FixedUpdate() {
		if (weaponMadeContact) {
			// HUOM! Kerrotaanko empoweredHitVector tarkoituksella kaksi kertaa multiplierilla? Sekä tässä, että vektorin tallennuksessa OnCollisionEnterissä. Poista, jos kommentti turha.
			victimRigidbody.AddForce (empoweredHitVector);
			//print ("Adding BOW POWER");

			if (hitConnectedBody & victimReadyForAnotherDamageBlow) {
				DamageVictim ();
				victimReadyForAnotherDamageBlow = false;
			}

			if (forceCooldownPassed > forceCooldown) {
				weaponMadeContact = false;
				hitConnectedBody = false;
				victimReadyForAnotherDamageBlow = true;
			}
		}
	}

	void DamageVictim() {
		victimReceiveDamage.HitReceived (victimsBodypart, damageForce);
	}

	void OnCollisionEnter(Collision col) {
		if (gameObject.layer - 1 != col.gameObject.layer && col.gameObject.layer != 16) {
			if (cooldownPassed > cooldown) {
				victimRigidbody = col.gameObject.GetComponent<Rigidbody> ();
				forceCooldownPassed = 0;
				weaponMadeContact = true;

				if (col.gameObject.tag != "Weapon") {
					empoweredHitVector = weaponRigidbody.velocity * extraPowerMultiplier;

					victimReceiveDamage = col.gameObject.GetComponentInParent<ReceiveDamage> ();
					hitConnectedBody = true;
					victimsBodypart = col.gameObject.tag;
					damageForce = weaponRigidbody.velocity.magnitude;
					//print ("mihin osui: " + victimsBodypart);
					//print ("paljonko osui: " + damageForce);

				} else {
					empoweredHitVector = weaponRigidbody.velocity * extraPowerMultiplier * 0.5f;
					hitConnectedBody = false;
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
