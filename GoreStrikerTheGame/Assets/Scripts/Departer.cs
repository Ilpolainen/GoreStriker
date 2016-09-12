using UnityEngine;
using System.Collections;

public static class Departer : object {



	public static void cut(GameObject departedLimb, GameObject originalLimb, GameObject mesh) {
		//Leikkaa jointit
		cutJoints(departedLimb);
		//Asettaa massat oikein
		setMasses(departedLimb, originalLimb);
		//Asettaa Colliderit oikein
		setColliders(departedLimb, originalLimb);
		//VaihtaaMeshiennäkyvyydet
		changeMeshes(departedLimb, mesh);
	}	

	public static void handleChild(GameObject departedChildLimb, GameObject childLimb, GameObject childMesh) {
		//Leikkaa vain fixedJointin
		Component.Destroy(departedChildLimb.GetComponent<FixedJoint> ());
		setMasses (departedChildLimb, childLimb);
		setColliders (departedChildLimb, childLimb);
		changeMeshes (departedChildLimb, childMesh);
	}

	private static void cutJoints(GameObject limb){
		Component.Destroy(limb.GetComponent<FixedJoint> ());
		Component.Destroy (limb.GetComponent<CharacterJoint> ());
	}

	private static void setMasses(GameObject departedLimb, GameObject originalLimb){
		Rigidbody body = departedLimb.GetComponent<Rigidbody> ();
		body.mass = 1;
		body.useGravity = true;
		originalLimb.GetComponent<Rigidbody> ().mass = 0.01f;
	}

	private static void setColliders(GameObject departedLimb, GameObject originalLimb){
		Collider[] departedColliders = departedLimb.GetComponents<Collider> ();
		foreach (Collider col in departedColliders) {
			col.enabled = true;
		}
		Collider[] invisibleColliders = originalLimb.GetComponents<Collider> ();
		foreach (Collider col in invisibleColliders) {
			col.enabled = false;
		}
	}

	private static void changeMeshes(GameObject departedLimb, GameObject mesh){
		GameObject armature = departedLimb.transform.parent.gameObject;
		Renderer[] renderers = armature.transform.GetComponentsInChildren<Renderer>();
		foreach (Renderer r in renderers) {
			r.enabled = true;
		}
		mesh.GetComponent<Renderer> ().enabled = false;
	}
}
