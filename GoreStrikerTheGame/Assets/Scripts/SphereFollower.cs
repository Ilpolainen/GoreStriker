using UnityEngine;
using System.Collections;

public class SphereFollower : MonoBehaviour {

	public float thrust;
	public GameObject target;
	private Transform targetPos;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		targetPos = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (thrust * (target.transform.position - transform.position + Vector3.up*4));
		print ("Target y = " + targetPos.position.y + ", vahennetaan = " + transform.position.y + 3);

	}
}
