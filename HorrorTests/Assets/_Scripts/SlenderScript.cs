using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SlenderScript : MonoBehaviour {

    public VideoPlayer staticVideo;

    public bool isVisible;

    public int test;

    public float damping;

    public float speed; 

    private Vector3 playerDir;

    private Quaternion rot;

    private GameObject target;
     
	void Start () {
        target = GameObject.Find("Player");
        staticVideo.gameObject.SetActive(false);
	}
	
	void Update () {

        //Debug.Log(1-(Vector3.Distance(transform.position, target.transform.position)/10));
        if (isVisible == true)
        {
            if (1 - (Vector3.Distance(transform.position, target.transform.position) / 10) >0.05f)
            {
                staticVideo.gameObject.SetActive(true);
            }
            else staticVideo.gameObject.SetActive(false);

        }
        if (isVisible == false)
        {
            staticVideo.gameObject.SetActive(false);


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
