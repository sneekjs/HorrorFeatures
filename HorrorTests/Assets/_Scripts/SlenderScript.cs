using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderScript : MonoBehaviour {

    public bool isVisible;

    public int test;

    public float damping;

    public float speed; 

    private Vector3 playerDir;

    private Quaternion rot;

    private GameObject target;
     
	void Start () {
        target = GameObject.Find("Player");
	}
	
	void Update () {
        if (isVisible == true)
        {

        }
        if (isVisible == false)
        {
            Debug.Log("InVisible");
            playerDir = target.transform.position - transform.position;
            playerDir.y = 0;
            rot = Quaternion.LookRotation(playerDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * damping);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
    }
}
