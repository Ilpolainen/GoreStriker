using UnityEngine;
using System.Collections;

public static class Departer : object {



	public static void cut(GameObject departedLimp, GameObject invisibleLimp, GameObject mesh) {
		//Leikkaa jointit
		Departer.cutJoints(departedLimp);
		//Asettaa massat oikein
		Departer.setMasses(departedLimp, invisibleLimp);
		//Asettaa Colliderit oikein
		Departer.setColliders(departedLimp, invisibleLimp);
		//VaihtaaMeshiennäkyvyydet
		Departer.changeMeshes(departedLimp, mesh);
	}	

	private static void cutJoints(GameObject limp){
		
		Component[] joints = limp.GetComponentsInChildren<FixedJoint> ();
		foreach (FixedJoint joint in joints) {
			Component.Destroy(joint);
		}
	}

	private static void setMasses(GameObject departedLimp, GameObject invisibleLimp){
		Rigidbody[] bodies = departedLimp.GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody r  in bodies) {
			r.mass = 1;
			r.useGravity = true;
		}
		invisibleLimp.GetComponent<Rigidbody> ().mass = 0.1f;
	}

	private static void setColliders(GameObject departedLimp, GameObject invisibleLimp){
		Collider[] departedColliders = departedLimp.GetComponentsInChildren<Collider> ();
		foreach (Collider col in departedColliders) {
			col.enabled = true;

		}
		Collider[] invisibleColliders = invisibleLimp.GetComponentsInChildren<Collider> ();
		foreach (Collider col in invisibleColliders) {
			col.enabled = false;
		}
	}

	private static void changeMeshes(GameObject departedLimp, GameObject mesh){
		GameObject armature = departedLimp.transform.parent.gameObject;

		Renderer[] renderers = armature.transform.GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in renderers) {
			r.enabled = true;
		}
		mesh.GetComponentInChildren<Renderer> ().enabled = false;
	}
}
