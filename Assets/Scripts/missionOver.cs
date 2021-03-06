﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;

public class missionOver : MonoBehaviour {

	public Text eKilled, rockC, seedC, foodC, scoreF, survival, conORfai;
	public bool survived;
    GameObject hero;
	private hero_controller hc;
	public GameObject gameScreen, rtb;
	private gameScript gs;
	private string jsonStringR;
	private JsonData requiredDataR;
	public Text[] required = new Text[4];
	public AudioClip clk;
	//private JsonData statusInfo;

	//KeyValuePair<string,object> l = new KeyValuePair<string,object>("r",statusInfo);

	void Awake(){
		hero = GameObject.Find ("hero_weapon");
	}
	// Use this for initialization
	void Start () {
		survived = false;
		hc = hero.GetComponent<hero_controller> ();
		gs = gameScreen.GetComponent<gameScript> ();
//		statusInfo["Planets"][0]["status"] = "sfhsdgds";
		//File.WriteAllText ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_planetsInfo.json", (statusInfo ["Planets"] [0] ["status"]));

	}
	
	// Update is called once per frame
	void Update () {
		readRequirements ();
		eKilled.text = hc.eK_count.ToString ();
		rockC.text = hc.perRock.ToString ();
		seedC.text = hc.perSeed.ToString ();
		foodC.text = hc.finalFoodInt.ToString ();
		scoreF.text = hc.finalScoreInt.ToString ();

		if (hc.curr_health > 0 && gs.timer.fillAmount<=0) {
			survival.text = "YES";
			survived = true;
		} 

		else {
			survival.text = "NO";
			survived = false;
		}

		if (hc.eK_count >= int.Parse((requiredDataR ["Requirements"] [GameController.control.plaIndex] [0]).ToString())
			&& hc.perRock >= int.Parse((requiredDataR ["Requirements"] [GameController.control.plaIndex] [1]).ToString())
			&& hc.perSeed >= int.Parse((requiredDataR ["Requirements"] [GameController.control.plaIndex] [2]).ToString())
			&& hc.finalFoodInt >= int.Parse((requiredDataR ["Requirements"] [GameController.control.plaIndex] [3]).ToString())
			&& survived == true) {
			conORfai.text = "Conquered ! ! !";
			GameController.control.array[GameController.control.plaIndex] = "Completed";
		} 

		else {
			conORfai.text = "Failed";
		}
			
	}

	void readRequirements(){
		jsonStringR = File.ReadAllText (Application.streamingAssetsPath + "/successRequirements.json");
		requiredDataR = JsonMapper.ToObject (jsonStringR);
		for (int j = 0; j < required.Length; j++) {
			required [j].text = (requiredDataR ["Requirements"] [GameController.control.plaIndex] [j]).ToString ();
		}
	}

	public void returnToBase(){
		SceneManager.LoadScene ("GameToMissions");
		GameController.control.Save ();
		rtb.GetComponent<AudioSource> ().PlayOneShot (clk);
		//string[] statusToFile = GameController.control.array;
		//string separator = " ";
		//string finalStatus = "";
		//for (int i = 0; i < GameController.control.array.Length; i++) {
		//	finalStatus = string.Join (separator, statusToFile);
		//}
		//if (File.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt")) {
			//File.WriteAllText ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt",finalStatus);
		//	Debug
	//	}
	}
}