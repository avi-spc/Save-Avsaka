using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spaceCraft : MonoBehaviour {

	public GameObject plaAvsaka, reachPoint;
	public AudioClip spaceship;
	//public bool e;
	// Use this for initialization
	void Start () {
		//e = false;
	}
		
	// Update is called once per frame
	void Update () {
		plaAvsaka.transform.Rotate (new Vector3 (0, 45, 0) * 0.5f * Time.deltaTime) ;
		transform.Rotate (new Vector3 (0, 45, 0) * Time.deltaTime);
		GetComponent<Rigidbody> ().AddForce ((reachPoint.transform.position - transform.position).normalized * 4);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Avsaka")) {
			GameController.control.m = true;
			SceneManager.LoadScene ("AvsakaRestore");
			//e = true;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("avPla")) {
			GetComponent<AudioSource> ().PlayOneShot (spaceship);
		}
	}
}
