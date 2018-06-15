using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hero_controller : MonoBehaviour {

	public int speed, perScore, finalScoreInt, perFood, finalFoodInt, perSeed, perRock, eK_count;
    private Animator anim;
    bool isWalking, isFiring, isSlashing;
	public float killRayLength, finalScore, finalFood, curr_health, max_health = 100f, health_rate, v,cla;
    public Transform gun;
    int floorMask;
    float rayLength;
    Rigidbody player;
    public Ray gunRay;
    public RaycastHit gunHit;
    public ParticleSystem ps;
    public Text scoreText, seed, rock, food, ekills;
    public Image hero_health;
    public GameObject dead_hero;
	public AudioClip laser, wak, e_hit, k;
    public LineRenderer line;
    AudioSource s;
    
	void Start () {
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isWalking = false;
        isFiring = false;
        isSlashing = false;
        floorMask = LayerMask.GetMask("Ground");
        rayLength = 1000f;
        killRayLength = 10f;
        ps.enableEmission = false;
        perScore  = perFood = perRock = perSeed = 0;
        curr_health = max_health;
		eK_count = 0;
       //s = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update () {
		cla = transform.position.y;
		//transform.position.y = Mathf.Clamp (0.5f, 5, 10);
		if (isWalking == true) {
			foots ();
		}
		if (isFiring == true) {
			fire ();
		}
        if (curr_health <= 0)
        {
            curr_health = 0;
        }

        if (curr_health <= 0)
        {
            Destroy(gameObject);
            Instantiate(dead_hero, transform.position, transform.rotation);
        }

        gun.gameObject.SetActive(false);

        ps.enableEmission = false;

        isWalking = false;
        anim.SetBool("Walking",isWalking);

        isFiring = false;
        anim.SetBool("Firing", isFiring);

        isSlashing = false;
        anim.SetBool("Slashing", isSlashing);

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
			//GetComponent<Rigidbody> ().position = new Vector3 (transform.position.x, Mathf.Clamp (0.5f, 2, 3), transform.position.z);
            isWalking = true;
            anim.SetBool("Walking", isWalking);
            ps.enableEmission = true;
        }   

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            isWalking = true;
            anim.SetBool("Walking", isWalking);
            ps.enableEmission = true;
        }

        if (Input.GetKey(KeyCode.Space)) {
            isFiring = true;
            anim.SetBool("Firing", isFiring);
            gun.gameObject.SetActive(true);
           
        }

        if (Input.GetKey(KeyCode.Mouse1)) {
            isSlashing = true;
            anim.SetBool("Slashing", isSlashing);   
        }

        TurnAround();

        gunRay = new Ray(gun.transform.position,gun.transform.forward*killRayLength);
        Debug.DrawRay(gun.transform.position,gun.transform.forward*killRayLength,Color.blue);


        increaseScore();
        increaseFood();
        rock.text = perRock.ToString();
        seed.text = perSeed.ToString();
		ekills.text = eK_count.ToString ();
    }
		
	void TurnAround() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength, floorMask)) {
            Vector3 playerLook = hit.point - transform.position;
            playerLook.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(-playerLook);
            player.MoveRotation(newRotation);
        }
    }

    void increaseScore()
    {
        if (finalScore < perScore)
		{
			//Invoke ("d",0.5f);
            finalScore = finalScore + (Mathf.InverseLerp(0, perScore, 50f));
            finalScoreInt = (int)finalScore;
            scoreText.text = finalScoreInt.ToString();
        }
    }

    void increaseFood()
    {
        if (finalFood < perFood)
        {
            finalFood = finalFood + (Mathf.InverseLerp(0, perFood, 50f));
            finalFoodInt = (int)finalFood;
            food.text = finalFoodInt.ToString();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("E1"))
        {
            health_rate = 0.2f;
            changeHealth(health_rate);
			GetComponent<AudioSource> ().PlayOneShot (e_hit);
        }

        if (col.gameObject.CompareTag("E2"))
        {
            health_rate = 1f;
            changeHealth(health_rate);
			GetComponent<AudioSource> ().PlayOneShot (e_hit);
        }

        if (col.gameObject.CompareTag("drowned")) {
            Invoke("drown", 0.2f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("E3"))
        {
            health_rate = 2f;
            changeHealth(health_rate);
			GetComponent<AudioSource> ().PlayOneShot (e_hit);
        }

        if (col.gameObject.CompareTag("E2_thrower")) {
            health_rate = 2f;
            changeHealth(health_rate);
			GetComponent<AudioSource> ().PlayOneShot (e_hit);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Armors"))
        {
            health_rate = 1f;
            changeHealth(health_rate);
        }
		//GetComponent<AudioSource> ().PlayOneShot (e_hit);
    }

   // void OnParticleCollision(GameObject other)
    //{
    //    other = GetComponent<GameObject>();
   //     health_rate = 10f;
   //     changeHealth(health_rate);
		//GetComponent<AudioSource> ().PlayOneShot (e_hit);
   // }

    public void changeHealth(float health)
    {
        curr_health = curr_health - health;
        hero_health.fillAmount = curr_health / max_health;
    }

	void foots(){
		v = Mathf.Repeat (Time.time, 0.5f);
		if(v>0.2f && v<0.22f)
			GetComponent<AudioSource> ().PlayOneShot (wak);
	}

	void fire(){
		v = Mathf.Repeat (Time.time, 0.5f);
		if(v>0.1f && v<0.12f)
			GetComponent<AudioSource> ().PlayOneShot (laser);
	}

    void drown() {
        curr_health = 0;
    }
		
}
