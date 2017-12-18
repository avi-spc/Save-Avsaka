	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class gameScript : MonoBehaviour {

    public float time;
    public Image timer, pauseBanner;
    private Animator anim;
	private hero_controller hc;
    public bool comeIn;
    public int ch, randomEnemy, randomSpawnPoints, foodP;
	public float v,c;
	public Text userPlay;
	public Text[] mandlInfo = new Text[2];
	public GameObject egg, pausePanel, miOverPanel, box;
	public GameObject[] enemies;
	public Transform[] spawnPoints, foodPoints;
	GameObject eggI, hero, b_box;
	private string jsonStringML;
	private JsonData mandlInfoData;
	// Use this for initialization

	void Awake(){
		hero = GameObject.Find ("hero_weapon"); 
	//	box = GameObject.Find ("box");
		pausePanel.SetActive (false);
		miOverPanel.SetActive (false);
		GameController.control.m = true;
	}

	void Start () {
        time = 7200f;
        anim = GetComponent<Animator>();
        comeIn = false;
        ch = 0;
		userPlay.text = GameController.control.user_name;
		hc = hero.GetComponent<hero_controller> ();
		//readRequirements ();
		readmlInfo ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.timeScale == 1) {
			time--;
			timer.fillAmount = time / 7200f;
		}

		if(timer.fillAmount<=0f || hc.curr_health <=0){
			miOverPanel.SetActive (true);
			Time.timeScale = 0;
			pauseBanner.enabled = false;
			pausePanel.SetActive (false);
		}

		if (timer.fillAmount == 0.7f) {
			b_box = Instantiate (box);
		}

		if (timer.fillAmount == 0.223f) {
			//boxColl.enabled = false;
			b_box.GetComponent<BoxCollider>().isTrigger = true;
			//Instantiate (b_box, box.transform.position, box.transform.rotation);
		}

        if ((ch == -1 || ch == 0) && Input.GetKeyDown(KeyCode.Escape))
        {
            ch = 1;        
            //anim.SetTrigger("Ini");
			anim.SetInteger("1", ch);
			pausePanel.SetActive (true);
			Time.timeScale = 0;

        }

        else if (ch == 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            ch = -1;
            //anim.SetTrigger("Outi");
            anim.SetInteger("1", ch);
			pausePanel.SetActive (false);
			Time.timeScale = 1;
        }

		v = Mathf.Repeat (Time.time, 20f);
		if ((v > 19.5f && v < 19.6f) && timer.fillAmount>0f ) {
			enemyIns ();
		}

		c = Mathf.Repeat (Time.time, 10f);
		if ((c > 9.5f && c < 9.6f) && timer.fillAmount>0f ) {
			foodIns ();
		}

    }

	void enemyIns(){
		randomEnemy = Random.Range (0,3);
		randomSpawnPoints = Random.Range (0, 4);
		Instantiate (enemies[randomEnemy], spawnPoints[randomSpawnPoints].position, spawnPoints[randomSpawnPoints].rotation);
	}

	void foodIns(){
		foodP = Random.Range (0,9);
		eggI = Instantiate (egg, foodPoints [foodP].position, foodPoints [foodP].rotation);
		eggI.GetComponent<Animator> ().SetTrigger ("EggDisappear");
		Destroy (eggI,10f);
	}



	void readmlInfo(){
		jsonStringML = File.ReadAllText (Application.streamingAssetsPath + "/planetsInfo.json");
		mandlInfoData = JsonMapper.ToObject (jsonStringML);
		mandlInfo [0].text = (mandlInfoData ["Planets"] [GameController.control.plaIndex] [1]).ToString ();
		mandlInfo [1].text = (mandlInfoData ["Planets"] [GameController.control.plaIndex] [3]).ToString ();
	}
}
