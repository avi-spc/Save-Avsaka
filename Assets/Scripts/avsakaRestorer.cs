using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avsakaRestorer : MonoBehaviour {

	private Animator anim;
	public int planetNumber;

	void Awake(){
		planetNumber = GameController.control.countCom;
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch(planetNumber){
		case 1:
			anim.SetTrigger ("bM");
			break;
		case 2:
			anim.SetTrigger ("hou");
			break;
		case 3:
			anim.SetTrigger ("iM");
			break;
		case 4:
			anim.SetTrigger ("wat");
			break;
		case 5:
			anim.SetTrigger ("rC");
			break;
		case 6:
			anim.SetTrigger ("tre");
			break;
		default:
			;
			break;
		}
		transform.Rotate (new Vector3 (0, 45, 0) * Time.deltaTime);
	}
}
