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
		if (SceneManager.GetActiveScene().buildIndex == 4) {
			loadTime = 0;
			g ();
		}
		//loadingLevel.text = loadLevelName;
	}
	
	// Update is called once per frame
	void Update () {
		loadTime++;
		missionsLoader.fillAmount = loadTime / 100f;
		if (loadTime >= 100 && SceneManager.GetActiveScene().buildIndex == 4) {
			SceneManager.LoadScene ("Main Menu");
			loadingLevel.text = "Loading . . . MISSIONS";
		}

		if (loadTime >= 100 && SceneManager.GetActiveScene().buildIndex == 3) {
			SceneManager.LoadScene ("Main Menu");
			GameController.control.user_name = "";
			GameController.control.score = 0;
			loadingLevel.text = "Loading . . . MAIN MENU";
		}

		if (SceneManager.GetActiveScene ().buildIndex == 5) {
			loadingLevel.text = "Loading . . . " + loadLevelName;
			if (loadTime >= 100) {
				if (GameController.control.plaIndex == 0)
					SceneManager.LoadScene (6);
				else if (GameController.control.plaIndex > 0)
					SceneManager.LoadScene ("ComingSoon");
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
		if (File.Exists (Application.persistentDataPath + "/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt")) {
			File.WriteAllText (Application.persistentDataPath + "/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt",finalStatus);
			//	Debug
		}

		if (File.Exists (Application.persistentDataPath + "/" + GameController.control.user_name + "/" + GameController.control.user_name + "_percentCompletion.txt")) {
			File.WriteAllText (Application.persistentDataPath + "/" + GameController.control.user_name + "/" + GameController.control.user_name + "_percentCompletion.txt",c.ToString());
			//	Debug
		}
	}
}
