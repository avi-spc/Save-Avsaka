using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class material_Extraction : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    //private hero_controller hc;
    //public GameObject hero;
    //int collectibles;
    //public int filling;
    //Collider coll;
    //public Image fill;
    //// Use this for initialization
    //void Start()
    //{
    //    hc = hero.GetComponent<hero_controller>();
    //    collectibles = LayerMask.GetMask("Collectibles");
    //    filling = 100;
    //    coll = GetComponent<Collider>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (filling > 0)
    //    {
    //        if (coll.Raycast(hc.gunRay, out hc.gunHit, 1000f) && hc.gunHit.transform.tag == "Collectibles")
    //        {
    //            hc.mat_Ext = hc.mat_Ext + 1;
    //            filling--;
    //        }
    //    }

    //    fill.fillAmount = filling / 100f;
    //}
}
