using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class bu : MonoBehaviour {
	public string[] statusToFile = new string[6];
	public int c;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void g(){
		SceneManager.LoadScene ("Main Menu");
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
