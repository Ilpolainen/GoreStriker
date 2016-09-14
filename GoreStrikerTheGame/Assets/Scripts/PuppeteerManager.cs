using UnityEngine;
using System.Collections;

public class PuppeteerManager : MonoBehaviour {

	public GameObject puppeteer;

	private Animator puppeteerAnimator;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		puppeteerAnimator = puppeteer.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		puppeteerAnimator.SetFloat("speed",rb.velocity.magnitude);
		//print (rb.velocity.magnitude);
	}
}
