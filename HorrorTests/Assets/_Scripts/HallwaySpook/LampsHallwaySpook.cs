using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsHallwaySpook : MonoBehaviour {

    public GameObject eventTrigger;

    private GameObject player;
    private bool eventIsActive;
    private Light myLight;
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        myLight = gameObject.GetComponent<Light>();
        eventIsActive = false;

    }

    void Update () {
        if (eventIsActive == false)
        {
            if (Vector3.Distance(player.transform.position, eventTrigger.transform.position) < 3f)
            {
                eventIsActive = true;
                StartCoroutine(RandomDelay());
            }
        }
    }

    public IEnumerator RandomDelay()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        StartCoroutine(FlashingLights());
    }

    public IEnumerator FlashingLights()
    {
        myLight.enabled = false;
        Debug.Log("1");
        yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
        Debug.Log("2");
        myLight.enabled = true;
        yield return new WaitForSeconds(Random.Range(0f, 0.5f));
        StartCoroutine(FlashingLights());
    }
}