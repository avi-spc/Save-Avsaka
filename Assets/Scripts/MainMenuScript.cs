using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour {

    private Animator anim;
    public Canvas userInput;
    public Text userPerform;
    public Text start;
    //private AudioSource audioSource;
    public AudioClip button_over;

	void Awake(){
		//DontDestroyOnLoad (m);
		//GameController.control.m = false;
	}

    // Use this for initialization
    void Start() {
		anim = GetComponent<Animator> ();
		userInput.enabled = false;
		start.enabled = false;
		if (GameController.control.m == true) {
			MainToMissions ();
		}
		GameController.control.Load ();
	}

    // Update is called once per frame
    void Update() {
        userPerform.text = GameController.control.user_name;

    }

    public void OnHoverEnter()
    {
        anim.SetTrigger("Play");
        anim.SetTrigger("UserPlay");
        anim.SetTrigger("OPlay");
        anim.SetTrigger("MissPlay");
    }
    public void OnHoverExit() {
        anim.SetTrigger("Stop");
        anim.SetTrigger("UserStop");
        anim.SetTrigger("OStop");
        anim.SetTrigger("MissStop");
    }

    public void ToinputField() {
        userInput.enabled = true;
        start.enabled = true;
    }

    public void FrominputField() {
		if (GameController.control.user_name != "" && Directory.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name))
        {
            userInput.enabled = false;
            start.enabled = false;
        }
    }

    public void UserToMissions() {
		if(GameController.control.user_name != "" && Directory.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name))
            anim.SetTrigger("UsMi");
    }

    public void MainToUser() {
        anim.SetTrigger("MaUs");
    }

    public void UserToMain() {
        anim.SetTrigger("UsMa");
        userInput.enabled = false;
        start.enabled = false;
    }

    public void Exit() {
        Application.Quit();
    }

    public void MainToMissions() {
        anim.SetTrigger("MaMi");
		GameController.control.m = true;
    }

    public void MissionsToMain() {
        anim.SetTrigger("MiMa");
		GameController.control.m = false;
	//	int scene = SceneManager.GetActiveScene ().buildIndex;
//		GameController.control.user.text = "";
		SceneManager.LoadScene ("MiToMain");
    }

    public void MainToOptions() {
        anim.SetTrigger("MaOp");
    }

    public void OptionsToMain() {
        anim.SetTrigger("OpMa");
    }

    public void QuitToConfirm() {
        anim.SetTrigger("QTC");
    }

    public void ConfirmToQuit(){
        anim.SetTrigger("CTQ");
    }

    public void ToGame() {
		if (GameController.control.plaIndex > 0) {
			if (GameController.control.array [GameController.control.plaIndex - 1].Equals ("Completed"))
				SceneManager.LoadScene ("LevelTransfer");
		}

		else if(GameController.control.plaIndex == 0)
			SceneManager.LoadScene("LevelTransfer");
		
    }

    public void roundSound() {
        GetComponent<AudioSource>().PlayOneShot(button_over);
    }
}
