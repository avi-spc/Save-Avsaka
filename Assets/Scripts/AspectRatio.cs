﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AspectRatio : MonoBehaviour
{
	public bool isOld = true;
	public int countCompletion;
	public Text percentCom;
	public Text user;
	public Image percentBar;
	public Button but;

	void Start(){
		
	}

    void Update() {
		countCompletion = GameController.control.countCom;
		percentCom.text = GameController.control.perComNum.ToString();
		percentBar.fillAmount = GameController.control.perComNum / 100f;

		if (EventSystem.current.currentSelectedGameObject.name == "New Game") {
			isOld = false;
		}

		if(EventSystem.current.currentSelectedGameObject.name == "Load Game"){
			isOld = true;
		}


					
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

	public void createFile(){
		GameController.control.user_name = user.text;
		if (EventSystem.current.currentSelectedGameObject.name == "Start" && isOld == false) {
			if (!Directory.Exists (Application.persistentDataPath + "/" + GameController.control.user_name)) {
				Directory.CreateDirectory (Application.persistentDataPath + "/" + GameController.control.user_name);
				File.Copy (Application.streamingAssetsPath + "/statusInfo.txt",Application.persistentDataPath + "/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt",true);
				File.Create (Application.persistentDataPath + "/" + GameController.control.user_name + "/" + GameController.control.user_name + "_percentCompletion.txt");
				GameController.control.Save ();
			}
		}

		if(EventSystem.current.currentSelectedGameObject.name == "Start" && isOld == true){
			GameController.control.Load ();
		}

	}
}