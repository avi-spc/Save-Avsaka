using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class cloud : MonoBehaviour {

	public AudioClip clk;

	public void HoveEn(){
		GetComponent<Animator> ().SetTrigger ("enjoy");
	}	

	public void StartGame(){
		Invoke ("loadMainMenu", 0.4f);
		GetComponent<AudioSource> ().PlayOneShot (clk);
	}

	void loadMainMenu(){
		SceneManager.LoadScene ("Main Menu");
	}
}
