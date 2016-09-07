using UnityEngine;
using System.Collections;

public class SphereFollower : MonoBehaviour {

	public float thrust;
	private float originalThrust;
	public GameObject target;
	private Transform targetPos;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		targetPos = target.transform;

		originalThrust = thrust;
	}
	
	// Update is called once per frame
	void Update () {

		if (InputManager.GetLeftShoulderButtonInput ()) {
			thrust = thrust * 2f;
		} else {
			thrust = originalThrust;
		}
			
		rb.AddForce (thrust * (target.transform.position - transform.position));

		thrust = originalThrust;
	}
}
