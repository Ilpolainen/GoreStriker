using UnityEngine;
using System.Collections;

public class ReceiveDamage : MonoBehaviour {

	public float healthPoints;

	public float leftHipsHealth;
	const string LEFT_HIPS = "Left Hips";
	public float leftKneeHealth;
	const string LEFT_KNEE = "Left Knee";
	public float rightHipsHealth;
	const string RIGHT_HIPS = "Right Hips";
	public float rightKneeHealth;
	const string RIGHT_KNEE = "Right Knee";
	public float leftArmHealth;
	const string LEFT_ARM = "Left Arm";
	public float leftElbowHealth;
	const string LEFT_ELBOW = "Left Elbow";
	public float rightArmHealth;
	const string RIGHT_ARM = "Right Arm";
	public float rightElbowHealth;
	const string RIGHT_ELBOW = "Right Elbow";
	public float headHealth;
	const string HEAD = "Head";
	public float torsoHealth;
	const string TORSO = "Torso";


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HitReceived(string bodyPart, float power) {

		switch (bodyPart) {
		case LEFT_HIPS:
			//leftLegHealth -= power;
			//healthPoints -= power/3;

			print ("LL " + gameObject.tag + " poer: " + power);
			break;
		case LEFT_KNEE:

			print ("LK " + gameObject.tag + " poer: " + power);
			break;
		case RIGHT_HIPS:
			print ("RL " + gameObject.tag + " poer: " + power);
			break;
		case RIGHT_KNEE:
			print ("RE " + gameObject.tag + " poer: " + power);
			break;
		case LEFT_ARM:
			print ("LA " + gameObject.tag + " poer: " + power);
			break;
		case LEFT_ELBOW:
			print ("LE " + gameObject.tag + " poer: " + power);
			break;
		case RIGHT_ARM:
			print ("RA " + gameObject.tag + " poer: " + power);
			break;
		case RIGHT_ELBOW:
			print ("RE " + gameObject.tag + " poer: " + power);
			break;
		case HEAD:
			print ("head " + gameObject.tag + " poer: " + power);
			break;
		case TORSO:
			print ("torso " + gameObject.tag + " poer: " + power);
			break;
		default:
			//healthPoints -= power;

			print ("UNHANDLED TAG " + gameObject.tag + " poer: " + power);
			break;
		}
	}
}
