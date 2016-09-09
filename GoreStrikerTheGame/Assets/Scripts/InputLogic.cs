using UnityEngine;
using System.Collections;

public class InputLogic : MonoBehaviour {

	private GameObject man;
	// Use this for initialization
	void Start () {
		man = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("q")) {
			GameObject departed = man.transform.FindChild ("DepartedParts").FindChild ("DepartedLeftArm").FindChild ("Armature").FindChild ("DepartedUpperArm_L").gameObject;
			GameObject old = man.transform.FindChild ("Armature").FindChild ("LeftArm_L").gameObject;
			GameObject mesh = man.transform.FindChild ("MeshLeftArm").gameObject;
			Departer.cut (departed, old, mesh);
		}
		if (Input.GetKeyDown("w")) {
			GameObject departed = man.transform.FindChild ("DepartedParts").FindChild ("DepartedRightArm").FindChild ("Armature").FindChild ("DepartedUpperArm_R").gameObject;
			GameObject old = man.transform.FindChild ("Armature").FindChild ("RightArm_R").gameObject;
			GameObject mesh = man.transform.FindChild ("MeshRightArm").gameObject;
			Departer.cut (departed, old, mesh);
		}
		if (Input.GetKeyDown("e")) {
			GameObject departed = man.transform.FindChild ("DepartedParts").FindChild ("DepartedLeftLeg").FindChild ("Armature").FindChild ("DepartedHips_L").gameObject;
			GameObject old = man.transform.FindChild ("Armature").FindChild ("LeftHips_L").gameObject;
			GameObject mesh = man.transform.FindChild ("MeshLeftLeg").gameObject;
			Departer.cut (departed, old, mesh);
			GameObject.Find ("MiddleSpine").GetComponentInChildren<ConstantForce> ().force = GameObject.Find ("MiddleSpine").GetComponentInChildren<ConstantForce> ().force / 3;
		}
		if (Input.GetKeyDown("r")) {
			GameObject departed = man.transform.FindChild ("DepartedParts").FindChild ("DepartedRightLeg").FindChild ("Armature").FindChild ("DepartedHips_R").gameObject;
			GameObject old = man.transform.FindChild ("Armature").FindChild ("RightHips_R").gameObject;
			GameObject mesh = man.transform.FindChild ("MeshRightLeg").gameObject;
			Departer.cut (departed, old, mesh);
			GameObject.Find ("MiddleSpine").GetComponentInChildren<ConstantForce> ().force = GameObject.Find ("MiddleSpine").GetComponentInChildren<ConstantForce> ().force / 3;
		}

	}
}
