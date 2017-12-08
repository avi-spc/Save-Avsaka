using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t : MonoBehaviour {

	void Awake(){
		

	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Camera.main.transform.position*-1);	
	}
}
