using UnityEngine;
using System.Collections;

public class WeaponHitEmpower : MonoBehaviour {

	public float extraPowerMultiplier;
	Rigidbody weaponRigidbody;


	int cooldownPassed;
	int cooldown = 30;


	// Use this for initialization
	void Start () {
		weaponRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownPassed = cooldownPassed + 1;
	}

	void OnCollisionEnter(Collision col) {
		if (gameObject.layer - 1 != col.gameObject.layer && col.gameObject.layer != 16) {
			if (cooldownPassed > cooldown) {
				print ("BOW: " + (weaponRigidbody.velocity.magnitude * extraPowerMultiplier));
				col.gameObject.GetComponent<Rigidbody> ().AddForce (weaponRigidbody.velocity * extraPowerMultiplier);
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
