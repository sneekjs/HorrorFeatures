using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerSpook : MonoBehaviour {

    public GameObject eventTrigger;

    private GameObject player;
    private bool eventIsActive;

    private HingeJoint hinge;
    private JointMotor motor;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        eventIsActive = false;
        hinge = gameObject.GetComponent<HingeJoint>();
        motor = hinge.motor;
    }
	
	void Update () {
        if (eventIsActive == false)
        {
            if (Vector3.Distance(player.transform.position, eventTrigger.transform.position)<3f)
            {
                eventIsActive = true;
                StartCoroutine(RandomDelay());
            }
        }        
	}

    public IEnumerator RandomDelay()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        StartCoroutine(Slamming());
    }

    public IEnumerator Slamming()
    {
        hinge.useMotor = true;
        yield return new WaitForSeconds(0.02f);
        hinge.useMotor = false;
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        StartCoroutine(Slamming());
    }
}