using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class avsakaRestorer : MonoBehaviour {

	private Animator anim;
	public int planetNumber;
	public Image circle;
	public GameObject[] acquired = new GameObject[6];
	public GameObject rtb;
	public Text playerName, totalScore, nRY;
	public AudioClip clk;

	void Awake(){
		planetNumber = GameController.control.countCom;
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		for (int i = 0; i < acquired.Length; i++) {
			acquired [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		totalScore.text = GameController.control.score.ToString();
		playerName.text = GameController.control.user_name;
		if (planetNumber > 0) {
			nRY.enabled = false;
		}
		circle.transform.Rotate (new Vector3 (0, 0, 45)*0.3f*Time.deltaTime);

		switch(planetNumber){
		case 1:
			anim.SetTrigger ("bM");
			acquired [0].SetActive (true);
			break;
		case 2:
			anim.SetTrigger ("hou");
			acquired [1].SetActive (true);
			break;
		case 3:
			anim.SetTrigger ("iM");
			acquired [2].SetActive (true);
			break;
		case 4:
			anim.SetTrigger ("wat");
			acquired [3].SetActive (true);
			break;
		case 5:
			anim.SetTrigger ("rC");
			acquired [4].SetActive (true);
			break;
		case 6:
			anim.SetTrigger ("tre");
			acquired [5].SetActive (true);
			break;
		default:
			;
			break;
		}
		transform.Rotate (new Vector3 (0, 45, 0) * Time.deltaTime);
	}

	public void avToMiss(){
		SceneManager.LoadScene ("GameToMissions");
		rtb.GetComponent<AudioSource> ().PlayOneShot (clk);
	}
}
