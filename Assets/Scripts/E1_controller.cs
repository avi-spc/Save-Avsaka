using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class E1_controller : MonoBehaviour
{

    NavMeshAgent navig;
    public GameObject dead_E1;
    GameObject hero, tracker;
    private hero_controller hc;
    Vector3 heroToEnemy;
    bool isAttacking;
    private Animator anim;
    Rigidbody enemy_1;
    public int health;
    public Collider coll;
    public Image E1_health;
    public ParticleSystem ps;
    //private gameScore gs;
    //public GameObject gameSc;
    // Use this for initialization

    void Awake()
    {
        hero = GameObject.Find("hero_weapon");
        tracker = GameObject.FindWithTag("Player");
       // gameSc = GameObject.Find("score");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        navig = GetComponent<NavMeshAgent>();
        enemy_1 = GetComponent<Rigidbody>();
        isAttacking = false;
        health = 50;
        hc = hero.GetComponent<hero_controller>();
        navig.speed = Random.Range(1, 4);
        ps.enableEmission = false;
       // gs = gameSc.GetComponent<gameScore>();
    }

    // Update is called once per frame
    void Update()
    {
        heroToEnemy = transform.position - tracker.transform.position;
        ps.enableEmission = false;
        if (heroToEnemy.magnitude < 1.4f && hc.curr_health > 0 )
        {
            isAttacking = true;
            anim.SetBool("Attacking", isAttacking);
        }
        else
        {

            isAttacking = false;
            anim.SetBool("Attacking", isAttacking);
            navig.SetDestination(tracker.transform.position);
            ps.enableEmission = true;

        }

        LookToHero();
        EnemyHealth();
    }

    void LookToHero()
    {
        Vector3 eneToHero = transform.position - tracker.transform.position;
        eneToHero.y = 0f;
        Quaternion eneRotation = Quaternion.LookRotation(-eneToHero);
        enemy_1.MoveRotation(eneRotation);
    }

    void EnemyHealth()
    {
		if (coll.Raycast(hc.gunRay, out hc.gunHit, hc.killRayLength) && hc.gunHit.transform.tag == "E1" && Time.timeScale == 1)
        {
            health--;
            if (health <= 0)
            {
				hc.eK_count=hc.eK_count+1;
                hc.perScore = hc.perScore + 10;
                GameController.control.score = GameController.control.score + 10;
                Destroy(gameObject);
                Instantiate(dead_E1, transform.position, transform.rotation);
            }
        }

        E1_health.fillAmount = health / 50f;

    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("Hero"))
    //    {
    //        gs.health_rate = 0.2f;
    //        gs.changeHealth(gs.health_rate);
    //    }
    //}
}