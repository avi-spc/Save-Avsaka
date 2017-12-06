using System.Collections;
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
	public GameObject gameScreen;
	private gameScript gs;
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

		if (survived == true) {
			conORfai.text = "Conquored ! ! !";
			GameController.control.array[GameController.control.plaIndex] = "complete";
		} 

		else {
			conORfai.text = "Failed";
		}
			
	}

	public void returnToBase(){
		SceneManager.LoadScene ("Main Menu");
		string[] statusToFile = GameController.control.array;
		string separator = " ";
		string finalStatus = "";
		//for (int i = 0; i < GameController.control.array.Length; i++) {
			finalStatus = string.Join (separator, statusToFile);
		//}
		if (File.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt")) {
			File.WriteAllText ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt",finalStatus);
		//	Debug
		}
	}
}