using UnityEngine;
using System.Collections;

public class RotateTowards : MonoBehaviour {

	public GameObject target;

	public float force;

	Rigidbody rb;

	Vector3 targetDirection;
	Vector3 localTarget;
	Vector3 eulerAngleVelocity;
	Quaternion deltaRotation;

	float angle;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {
		targetDirection = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
		localTarget = transform.InverseTransformPoint (new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z));
		angle = Mathf.Atan2 (localTarget.x, localTarget.z) * Mathf.Rad2Deg;

		eulerAngleVelocity = new Vector3 (0,0, angle);
		deltaRotation = Quaternion.Euler (eulerAngleVelocity * Time.deltaTime);

		if (localTarget.magnitude > 0.3f) {
			rb.MoveRotation (rb.rotation * deltaRotation);
		}
	}
}
