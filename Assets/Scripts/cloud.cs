using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cloud : MonoBehaviour {
	public GameObject[] planets;
	public Text wlcmToBase;
	public Button[] p;
	public int w;
	public bool ac;
	public GameObject[] panel;
	public Text mcode, pname, wcapacity, dlevel, status;
	void Start()
	{
		ac = false;
		Time.timeScale = 1;
		for (int i=0;i<panel.Length;i++) {
			panel[i].SetActive(false);
		}

	}

	public void P0(int a) {

		for (int i = 0; i < panel.Length; i++)
		{
			panel[i].SetActive(false);
		}
		for (int i = 0; i < panel.Length; i++)
		{
			panel[i].SetActive(true);
		}
		for (int i = 0; i < panel.Length; i++)
		{
			panel[i].GetComponent<Animator>().SetTrigger("ShowInfo");
		}
		mcode.text = "23H2";
		pname.text = "Loprax";
		wcapacity.text = "110 Million Gallons";
		dlevel.text = "Moderate";
		status.text = "Incomplete";

		planets[a].SetActive(true);
		planets[a].GetComponent<Animator>().SetTrigger("Pop");

		if (a == 0) {
			for(int i=1;i<planets.Length-1;i++){
				planets [i].SetActive (false);
			}
		}

		else if (a == 5) {
			for(int i=0;i<planets.Length-2;i++){
				planets [i].SetActive (false);
			}
		}

		else {
			for(int i=0;i<a-1;i++){
				planets [i].SetActive (false);
			}

			for(int i=a+1;i<planets.Length-1;i++){
				planets [i].SetActive (false);
			}
		}

		wlcmToBase.enabled = false;
	}

	public void s(){
		if (EventSystem.current.currentSelectedGameObject.name == "0") {
			w = 0;	
		}

		if (EventSystem.current.currentSelectedGameObject.name == "1") {
			w = 1;	
		}

		if (EventSystem.current.currentSelectedGameObject.name == "2") {
			w = 2;	
		}

		if (EventSystem.current.currentSelectedGameObject.name == "3") {
			w = 3;	
		}

		if (EventSystem.current.currentSelectedGameObject.name == "4") {
			w = 4;	
		}

		if (EventSystem.current.currentSelectedGameObject.name == "5") {
			w = 5;	
		}

		P0 (w);
	}
}
