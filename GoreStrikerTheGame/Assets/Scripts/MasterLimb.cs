using UnityEngine;
using System.Collections;

public class MasterLimb : Limb {

	public GameObject connectedLimb;
	public GameObject connectedDepartedLimb;
	public GameObject connectedLimbMesh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Cut(){
		base.Cut ();
		Departer.handleChild (connectedDepartedLimb, connectedLimb, connectedLimbMesh);
	}
		
}
