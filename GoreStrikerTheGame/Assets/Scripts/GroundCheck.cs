using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	bool grounded;
	GameObject currentGround;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ground") {
			grounded = true;
			currentGround = col.gameObject;
		} else {
			grounded = false;
		}
	}

	public bool IsGrounded() {
		return grounded;
	}

	public GameObject GetCurrentGround() {
		return currentGround;
	}
}
