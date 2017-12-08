using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class env_Objects : MonoBehaviour {

	public int boxHits, surObjectIndex;
    public ParticleSystem extraction, lightning;
    public static int rockHits,plantHits;
	public GameObject broken_box, egg, cloud;
	public GameObject[] surpriseObjects = new GameObject[3];
    GameObject hero, surprise;
    int groundMask, envMask;
    public float t;
    private hero_controller hc;
    Collider coll;
    public Collider eggColl;
    private Animator anim;
    // Use this for initialization

    void Awake()
    {
        hero = GameObject.Find("hero_weapon");     
    }

    void Start () {
        hc = hero.GetComponent<hero_controller>();
        groundMask = LayerMask.GetMask("Ground");
        envMask = LayerMask.GetMask("Environment");
        boxHits = 0;
        coll = GetComponent<Collider>();
        anim = GetComponent<Animator>();
        extraction.enableEmission = false;
		rockHits = 0;
		plantHits = 0;
        //Invoke("LightningInstantiate", 2f);
        //// InvokeRepeating("LightningInstantiate", 2f, 2f);
    }

	void FixedUpdate(){
		surObjectIndex = Random.Range (2, 3	);
	}

	// Update is called once per frame
	void Update () {
		
        t = Time.deltaTime;
        if (coll.Raycast(hc.gunRay,out hc.gunHit,1000f) && hc.gunHit.transform.tag == "Box" && Input.GetKey(KeyCode.Space)) {
            boxHits++;
            if (boxHits >= 50) {
                //hc.perScore = hc.perScore + 100;
                Destroy(gameObject);

                GameObject box_Clone = Instantiate(broken_box,transform.position,transform.rotation);
				surprise = Instantiate (surpriseObjects [surObjectIndex], new Vector3(box_Clone.transform.position.x, box_Clone.transform.position.y + 3, box_Clone.transform.position.z), Quaternion.identity);
				if (surObjectIndex == 0) {
					hc.perRock = hc.perRock + 10000;
				} else if (surObjectIndex == 1) {
					hc.perSeed = hc.perSeed + 1000;
				} else if (surObjectIndex == 2) {
					hc.perFood = hc.perFood + 10;
					//surpriseObjects [0].GetComponent<Animator> ().SetTrigger ("comeRock");
					//surpriseObjects [0].GetComponent<Animator> ().SetTrigger ("goRock");
				}
                Destroy(box_Clone, 2f);
				Destroy (surprise, 4f);
            }
        }

        if (coll.Raycast(hc.gunRay, out hc.gunHit, 1000f) && hc.gunHit.transform.tag == "Rock" && Input.GetKey(KeyCode.Space))
        {
			hc.perRock = rockHits++;
            extraction.enableEmission = true;
            extraction.transform.position = hc.gunHit.point;
        }

        if (coll.Raycast(hc.gunRay, out hc.gunHit, 1000f) && hc.gunHit.transform.tag == "Plant" && Input.GetKey(KeyCode.Space))
        {
			hc.perSeed = plantHits++;
            extraction.enableEmission = true;
            extraction.transform.position = hc.gunHit.point;
        }

        if (!Physics.Raycast(hc.gunRay, out hc.gunHit, 1000f, envMask) && extraction.enableEmission == true)
        {
            extraction.enableEmission = false;
        }

    }

    void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("Hero")) {
			anim.SetTrigger ("EggCollect");
			eggColl.enabled = false;
			Destroy (egg, 1f);
			hc.perFood = hc.perFood + 50;
		} 
    }
    //void LightningInstantiate() {
    //    ParticleSystem p = Instantiate(lightning, new Vector3(6.8f, 13.6f, -7.9f), transform.rotation);
    //    Destroy(p, 2f);
    //   // Invoke("LightningInstantiate", 2f);
    //}

}
