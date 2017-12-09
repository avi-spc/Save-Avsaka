using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class E2_controller : MonoBehaviour {

    public GameObject dead_E2, attacker_pos;
    GameObject hero, tracker;
    NavMeshAgent navig;
    private hero_controller hc;
    private Animator anim;
    public bool isThrowing;
    public bool isSmacking;
    Vector3 heroToEnemy;
    Rigidbody enemy_2;
    public int health;
    public Collider coll1,coll2;
    public Image E2_health;
    public ParticleSystem ps;
    public float va;
    public Rigidbody attacker;
    Rigidbody ball;

    // Use this for initialization

    void Awake() {
        hero = GameObject.Find("hero_weapon");
        tracker = GameObject.FindWithTag("Player");
      //  attacker_pos = GameObject.Find("attacker_pos");
    }

    void Start () {
        navig = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isSmacking = false;
        isThrowing = false;
        enemy_2 = GetComponent<Rigidbody>();
        hc = hero.GetComponent<hero_controller>();
        health = 20;
        navig.speed = Random.Range(1,4);
        ps.enableEmission = false;
       // attacker.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       // 
        heroToEnemy = transform.position - tracker.transform.position;
        ps.enableEmission = false;
        if (heroToEnemy.magnitude < 1.8f && hc.curr_health > 0)
        {
            isSmacking = true;
            anim.SetBool("SAttack", isSmacking);
        }

        else {
            isSmacking = false;
            anim.SetBool("SAttack", isSmacking);
            navig.SetDestination(tracker.transform.position);
            ps.enableEmission = true;
        }

        LookToHero();
        EnemyHealth();        
	}

    void FixedUpdate()
    {
        va = Mathf.Repeat(Time.time, 2f);
        if (va == 1f && isSmacking == false && hc.curr_health > 0)
            Invoke("Attack", 0f);
    }

    void Attack() {
        ball = Instantiate(attacker, attacker_pos.transform.position, attacker_pos.transform.rotation);
        ball.AddForce(-heroToEnemy * 25f);
       // Destroy(ball, 1f);
    }

    void LookToHero() {
        Vector3 eneToHero = transform.position - tracker.transform.position;
        eneToHero.y = 0f;
        Quaternion eneRotation = Quaternion.LookRotation(-eneToHero);
        enemy_2.MoveRotation(eneRotation);
    }

    void EnemyHealth() {
		if ((coll1.Raycast(hc.gunRay, out hc.gunHit, hc.killRayLength) || coll2.Raycast(hc.gunRay, out hc.gunHit, hc.killRayLength)) && hc.gunHit.transform.tag == "E2" && Time.timeScale == 1)
        {
            health--;
            if (health <= 0)
            {
				hc.eK_count=hc.eK_count+1;
                hc.perScore = hc.perScore + 20;
                GameController.control.score = GameController.control.score + 20;
                Destroy(gameObject);
                Instantiate(dead_E2, transform.position, transform.rotation);
            }
        }

        E2_health.fillAmount = health / 20f;
    }
}
