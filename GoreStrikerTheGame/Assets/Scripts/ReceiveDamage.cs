using UnityEngine;
using System.Collections;

public class ReceiveDamage : MonoBehaviour {

	public float healthPoints;

	public float leftLegHealth;
	const string LEFT_LEG = "Left Leg";
	public float rightLegHealth;
	const string RIGHT_LEG = "Right Leg";
	public float leftArmHealth;
	const string LEFT_ARM = "Left Arm";
	public float rightArmHealth;
	const string RIGHT_ARM = "Right Arm";


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HitReceived(string bodyPart, float power) {
		switch (bodyPart) {
		case LEFT_LEG:
			//leftLegHealth -= power;
			//healthPoints -= power/3;

			//print ("LL");
			break;
		case RIGHT_LEG:
			//print ("RL");
			break;
		case LEFT_ARM:
			//print ("LA");
			break;
		case RIGHT_ARM:
			//print ("RA");
			break;
		default:
			//healthPoints -= power;

			//print ("default");
			break;
		}
	}
}
