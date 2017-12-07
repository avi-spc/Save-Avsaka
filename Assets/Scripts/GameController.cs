using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour {

    public static GameController control;
   // private hero_controller hc;
   /// public GameObject hero;
    
    public String user_name;
	public int score, plaIndex, countCom, perComNum;
	public bool m;
	public string[] array = new string[6];
	public float v;
	// Use this for initialization
	void Awake () {

       // hero = GameObject.Find("hero_weapon");

        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
			//DontDestroyOnLoad (user);
            control = this;
        }
        else if (control != this) {
            Destroy(gameObject);
        }
	}

    void Start()
    {
       // hc = hero.GetComponent<hero_controller>();
		    }

    ////Update is called once per frame
	/// 
	/// 

	void FixedUpdate(){
		//if (File.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt")) {
			StreamReader sr = new StreamReader ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt");
			//string[] array;
			string str = "";
			str = sr.ReadLine ();
			array = str.Split ();
		//}
		//if (File.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_percentCompletion")) {
			StreamReader sre = new StreamReader ("C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_percentCompletion.txt");
			if (sre.Equals (""))
				countCom = 0;
			countCom = int.Parse ((sre.ReadLine ()));
		//}
		switch (countCom) {
		case 1:
			perComNum = 8;
			break;
		case 2:
			perComNum = 20;
			break;
		case 3:
			perComNum = 35;
			break;
		case 4:
			perComNum = 50;
			break;
		case 5:
			perComNum = 75;
			break;
		case 6: 
			perComNum = 100;
			break;
		default:
			perComNum = 0;
			break;
		}

		}
		//}


    void Update()
    {
		//v = Mathf.Repeat (Time.time, 2f);
		//if(v<0.01f)



        //PlayerData data = new PlayerData();
        //score = hc.finalScoreInt;
        if (Input.GetKey(KeyCode.L)) {
            Save();
        }
        if (Input.GetKey(KeyCode.K)) {
            Load();
        }

    }

    void Save() {
        BinaryFormatter bformat = new BinaryFormatter();
		FileStream file = File.Create("C:/Users/Monster/Desktop/savedGames/"+user_name+".txt");
        PlayerData data = new PlayerData();
        data.score = score;
        data.user_name = user_name;
        bformat.Serialize(file,data);
        file.Close();
    }

    void Load() {
		if (File.Exists("C:/Users/Monster/Desktop/savedGames/" + user_name + ".txt"))
        {
            BinaryFormatter bformat = new BinaryFormatter();
			FileStream file = File.Open("C:/Users/Monster/Desktop/savedGames/" + user_name + ".txt", FileMode.Open);
            PlayerData data = (PlayerData)bformat.Deserialize(file);
            file.Close();
            user_name = data.user_name;
            score = data.score;
        }
       
    }

    [Serializable]
    public class PlayerData {

        public int score;
        public String user_name;
		//public string status;
    }

    public void noxt() {
        SceneManager.LoadScene("Setup");
    }
}
