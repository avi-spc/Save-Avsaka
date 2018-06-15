using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HTP : MonoBehaviour {

	void Awake(){
	//	((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}
	// Use this for initialization
	void Start () {
		Invoke ("nextMenu", 18.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("Main Menu");
		}
	}

	void nextMenu(){
		SceneManager.LoadScene ("Main Menu");
	}
}
