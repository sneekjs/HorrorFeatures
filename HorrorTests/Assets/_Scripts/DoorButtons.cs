﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtons : MonoBehaviour {
    Animator anim;
    GameObject parent;
    private int test;
    void Start () {
        anim = null;

    }
	
	void Update () {

        RaycastHit hit;
        Ray myRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 1.5f);

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(myRay, out hit, 1.5f))
        {
            if (hit.collider.CompareTag("DoorButton"))
            {
                test++;
                Debug.Log("ButtonHit" + test);
                parent = hit.transform.parent.gameObject;
                anim = parent.transform.GetComponentInChildren<Animator>();
                if (anim.GetInteger("State") == 0)
                {
                    anim.SetInteger("State", 1);
                }else if(anim.GetInteger("State") == 1)
                {
                    anim.SetInteger("State", 0);
                }
            }
        }
    }
}