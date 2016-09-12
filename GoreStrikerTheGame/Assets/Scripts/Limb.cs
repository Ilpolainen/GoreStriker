using UnityEngine;
using System.Collections;

public class Limb : MonoBehaviour {

	// Use this for initialization
	public GameObject departedVersion;
	public GameObject mesh;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public virtual void Cut () {
		Departer.cut (departedVersion, this.gameObject, mesh);
	}
}
