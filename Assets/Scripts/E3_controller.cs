using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class E3_controller : MonoBehaviour {

    public GameObject dead_E3;
    GameObject hero, tracker;
    NavMeshAgent navig;
    Rigidbody enemy_3;
    private hero_controller hc;
    Vector3 heroToEnemy;
    private Animator anim;
    public bool isFisting;
    public int health;
    public Collider coll1, coll2, coll3;
    public Image E3_health;
    public ParticleSystem ps;

    void Awake() {
        hero = GameObject.Find("hero_weapon");
        tracker = GameObject.FindWithTag("Player");
    }

    // Use this for initialization
    void Start() {
        enemy_3 = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        navig = GetComponent<NavMeshAgent>();
        isFisting = false;
        hc = hero.GetComponent<hero_controller>();
        health = 100;
        navig.speed = Random.Range(1, 4);
        ps.enableEmission = false;
       

    }

    // Update is called once per frame
    void Update() {

        heroToEnemy = transform.position - tracker.transform.position;
        ps.enableEmission = false;
        if (heroToEnemy.magnitude < 2.5f && hc.curr_health > 0)
        {
            isFisting = true;
            anim.SetBool("FistAttack", isFisting);
        }
        else{
            isFisting = false;
            anim.SetBool("FistAttack", isFisting);
            navig.SetDestination(tracker.transform.position);
            ps.enableEmission = true;
        }
        LookToHero();
        EnemyHealth();
    }

    void LookToHero() {
        Vector3 eneToHero = transform.position - tracker.transform.position;
        eneToHero.y = 0f;
        Quaternion eneRotation = Quaternion.LookRotation(-eneToHero);
        enemy_3.MoveRotation(eneRotation);
    }

    void EnemyHealth() {
		if ((coll1.Raycast(hc.gunRay, out hc.gunHit, hc.killRayLength) || coll2.Raycast(hc.gunRay, out hc.gunHit, hc.killRayLength) || coll3.Raycast(hc.gunRay, out hc.gunHit, hc.killRayLength)) && hc.gunHit.transform.tag == "E3")
        {
            health--;
            if (health <= 0)
            {
				hc.eK_count=hc.eK_count+1;
                hc.perScore = hc.perScore + 50;
                GameController.control.score = GameController.control.score + 50;
                Destroy(gameObject);
                Instantiate(dead_E3, transform.position, transform.rotation);
            }
        }

        E3_health.fillAmount = health / 100f;
    }
}
