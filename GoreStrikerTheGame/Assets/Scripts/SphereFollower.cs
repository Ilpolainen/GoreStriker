using UnityEngine;
using System.Collections;

public class SphereFollower : MonoBehaviour {

	public float thrust;
	private float originalThrust;
	public GameObject target;
	private Transform targetPos;
	private Rigidbody rb;

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
	}
	
	// Update is called once per frame
	void Update () {

		if (InputManager.GetLeftShoulderButtonInput (playerName)) {
			thrust = thrust * 2f;
		} else {
			thrust = originalThrust;
		}


		rb.AddForce (thrust * (target.transform.position - transform.position));

		print ((thrust * (target.transform.position - transform.position)).magnitude); 

		thrust = originalThrust;
	}
}
