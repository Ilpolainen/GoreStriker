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
		targetDirection = target.transform.position - transform.position;
		localTarget = transform.InverseTransformPoint (target.transform.position);
		angle = Mathf.Atan2 (localTarget.x, localTarget.z) * Mathf.Rad2Deg;

		print (localTarget.magnitude);

		eulerAngleVelocity = new Vector3 (0,0, angle);
		deltaRotation = Quaternion.Euler (eulerAngleVelocity * Time.deltaTime);

		if (localTarget.magnitude > 0.3f) {
			rb.MoveRotation (rb.rotation * deltaRotation);
		}
	}
}
