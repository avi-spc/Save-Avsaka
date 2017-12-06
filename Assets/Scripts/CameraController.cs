using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject tracker;
    Transform camtransform;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        camtransform = GetComponent<Transform>();
        offset = camtransform.position - tracker.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPos = tracker.transform.position + offset;
        camtransform.position = Vector3.Lerp(camtransform.position,newPos,0.03f);
        }
}
