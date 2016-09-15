using UnityEngine;
using System.Collections;

public class IgnoreGroundCollision : MonoBehaviour {
	public Collider ground;
	// Use this for initialization
	void Start () {
		Collider collider = GetComponent<Collider> ();
		Physics.IgnoreCollision (ground, collider);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
