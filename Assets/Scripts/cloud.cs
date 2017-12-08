using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class cloud : MonoBehaviour {
	public void mitomain(){
		SceneManager.LoadScene ("Main Menu");
		GameController.control.user_name = "";
	}	
}
