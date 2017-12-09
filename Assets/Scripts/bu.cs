using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class bu : MonoBehaviour {
	public string[] statusToFile = new string[6];
	public int c;
	public Image missionsLoader;
	public int loadTime;
	public string loadLevelName;
	public Text loadingLevel;

	void Awake(){
		loadLevelName = GameController.control.levelName;
		//missionsLoader = Image.FindObjectOfType<Image> ();
	}

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene().buildIndex == 2) {
			loadTime = 0;
			g ();
		}
		//loadingLevel.text = loadLevelName;
	}
	
	// Update is called once per frame
	void Update () {
		loadTime++;
		missionsLoader.fillAmount = loadTime / 100f;
		if (loadTime >= 100 && SceneManager.GetActiveScene().buildIndex == 2) {
			SceneManager.LoadScene ("Main Menu");
			loadingLevel.text = "Loading . . . MISSIONS";
		}

		if (loadTime >= 100 && SceneManager.GetActiveScene().buildIndex == 1) {
			SceneManager.LoadScene ("Main Menu");
			GameController.control.user_name = "";
			GameController.control.score = 0;
			loadingLevel.text = "Loading . . . MAIN MENU";
		}

		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			loadingLevel.text = "Loading . . . " + loadLevelName;
			if (loadTime >= 100) {
				
				SceneManager.LoadScene (GameController.control.plaIndex + 4);
			}
		}

	}

	 void g(){
		//SceneManager.LoadScene ("Main Menu");
		statusToFile = GameController.control.array;
		foreach (string a in GameController.control.array) {
			if (a == "Completed") {
				c++;
			//	GameController.control.countCom = c;	
			}
		}
		string separator = " ";
		string finalStatus = "";
		//for (int i = 0; i < GameController.control.array.Length; i++) {
		finalStatus = string.Join (separator, statusToFile);
		//}
		if (File.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt")) {
			File.WriteAllText ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt",finalStatus);
			//	Debug
		}

		if (File.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_percentCompletion.txt")) {
			File.WriteAllText ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_percentCompletion.txt",c.ToString());
			//	Debug
		}
	}
}
