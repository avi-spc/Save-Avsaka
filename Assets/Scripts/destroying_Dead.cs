using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroying_Dead : MonoBehaviour {

    Rigidbody dead;
	// Use this for initialization
	void Start () {
        dead = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        Destroy(dead,2f);
	}
}
