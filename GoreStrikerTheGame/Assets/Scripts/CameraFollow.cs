using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject head;
	Transform headLocation;
	Vector3 previousHeadLocation;
	Vector3 difference;

	// Use this for initialization
	void Start () {
		headLocation = head.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (previousHeadLocation.x == null) {
			previousHeadLocation = headLocation.position;
		}


		difference = headLocation.position - previousHeadLocation;

		transform.position = transform.position + difference;


		previousHeadLocation = headLocation.position;
	}
}
