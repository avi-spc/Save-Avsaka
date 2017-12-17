using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemocS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("BackFromDemo",3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackFromDemo(){
		SceneManager.LoadScene ("GameToMissions");		
	}
}
