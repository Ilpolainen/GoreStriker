using UnityEngine;
using System.Collections;

public class IgnoreLegCollision : MonoBehaviour {

	public Collider leftUpperLeg;
	public Collider leftLowerLeg;
	public Collider rightUpperLeg;
	public Collider rightLowerLeg;

	public Collider otherSphere;

	private Collider lowerBodyBox;

	// Use this for initialization
	void Start () {

		lowerBodyBox = GetComponent<Collider> ();

		Physics.IgnoreCollision (lowerBodyBox, leftUpperLeg);
		Physics.IgnoreCollision (lowerBodyBox, leftLowerLeg);
		Physics.IgnoreCollision (lowerBodyBox, rightUpperLeg);
		Physics.IgnoreCollision (lowerBodyBox, rightLowerLeg);
		Physics.IgnoreCollision (lowerBodyBox, otherSphere);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
