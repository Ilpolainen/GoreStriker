using UnityEngine;
using System.Collections;

public class IgnoreLegCollision : MonoBehaviour {

	public Collider leftUpperLeg;
	public Collider leftLowerLeg;
	public Collider rightUpperLeg;
	public Collider rightLowerLeg;

	private Collider lowerBodyBox;

	// Use this for initialization
	void Start () {

		lowerBodyBox = GetComponent<BoxCollider> ();

		Physics.IgnoreCollision (lowerBodyBox, leftUpperLeg);
		Physics.IgnoreCollision (lowerBodyBox, leftLowerLeg);
		Physics.IgnoreCollision (lowerBodyBox, rightUpperLeg);
		Physics.IgnoreCollision (lowerBodyBox, rightLowerLeg);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
