using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class test : MonoBehaviour {

    public GameObject[] planets;
	public static int index;
	public Text wlcmToBase;
    public bool ac;
    public GameObject[] panel;
	public Text[] plaInfo = new Text[5];
	private string jsonString;
	private JsonData planetsData;

    void Start()
    {
		//plaInfo = {mcode, pname, pdistance, dlevel, status}; 
        ac = false;
		Time.timeScale = 1;
        for (int i=0;i<panel.Length;i++) {
            panel[i].SetActive(false);
        }
		index = -1;
		// 	GameController.control.plaIndex = -1;

    }

	void Update(){
		GameController.control.plaIndex = index;
		GameController.control.levelName = (planetsData ["Planets"] [index][1]).ToString();
	}

    public void P0() {

		index = 0;

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
  
        planets[0].SetActive(true);
        planets[0].GetComponent<Animator>().SetTrigger("Pop");
        planets[1].SetActive(false);
        planets[2].SetActive(false);
        planets[3].SetActive(false);
        planets[4].SetActive(false);
        planets[5].SetActive(false);
		wlcmToBase.enabled = false;
		//GameController.control.plaIndex = index;
		readData (index);
    }

    public void P1() {

		index = 1;

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
       
		planets [1].SetActive (true);
        planets[1].GetComponent<Animator>().SetTrigger("Pop");
        planets[0].SetActive(false);
        planets[2].SetActive(false);
        planets[3].SetActive(false);
        planets[4].SetActive(false);
        planets[5].SetActive(false);
		wlcmToBase.enabled = false;
		//GameController.control.plaIndex = index;
		readData (index);
    }

	public void P2() {

		index = 2;

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
        planets[2].SetActive(true);
        planets[2].GetComponent<Animator>().SetTrigger("Pop");
        planets[1].SetActive(false);
        planets[0].SetActive(false);
        planets[3].SetActive(false);
        planets[4].SetActive(false);
        planets[5].SetActive(false);
		wlcmToBase.enabled = false;
		//GameController.control.plaIndex = index;
		readData (index);
    }

    public void P3() {

		index = 3;

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
        planets[3].SetActive(true);
        planets[3].GetComponent<Animator>().SetTrigger("Pop");
        planets[1].SetActive(false);
        planets[2].SetActive(false);
        planets[0].SetActive(false);
        planets[4].SetActive(false);
        planets[5].SetActive(false);
		wlcmToBase.enabled = false;
		//GameController.control.plaIndex = index;
		readData (index);
    }

    public void P4() {

		index = 4;

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
        planets[4].SetActive(true);
        planets[4].GetComponent<Animator>().SetTrigger("Pop");
        planets[1].SetActive(false);
        planets[2].SetActive(false);
        planets[3].SetActive(false);
        planets[0].SetActive(false);
        planets[5].SetActive(false);
		wlcmToBase.enabled = false;
		//GameController.control.plaIndex = index;
		readData (index);
    }

    public void P5() {

		index = 5;

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
        planets[5].SetActive(true);
        planets[5].GetComponent<Animator>().SetTrigger("Pop");
        planets[1].SetActive(false);
        planets[2].SetActive(false);
        planets[3].SetActive(false);
        planets[4].SetActive(false);
        planets[0].SetActive(false);
		wlcmToBase.enabled = false;
		//GameController.control.plaIndex = index;
		readData (index);
    }

	void readData(int i){
		jsonString = File.ReadAllText("C:/Users/Monster/Desktop/planetsInfo.json");
		planetsData = JsonMapper.ToObject (jsonString);
		for (int j = 0; j < plaInfo.Length-1; j++) {
			plaInfo[j].text = (planetsData ["Planets"] [i][j]).ToString();
		}

		plaInfo [plaInfo.Length - 1].text = (GameController.control.array [index]).ToString ();

		//mcode.text = (planetsData ["Planets"] [i][0]).ToString();
		//pname.text = (planetsData ["Planets"] [i][1]).ToString();
		//pdistance.text = (planetsData ["Planets"] [i]["pdistance"]).ToString();
	//	dlevel.text = (planetsData ["Planets"] [i]["dlevel"]).ToString();
		//status.text = (planetsData ["Planets"] [i]["status"]).ToString();
	}
}
