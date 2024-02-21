using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public GameObject lightObj;
    private float rand;

    void FixedUpdate()
    {
        StartCoroutine("Flicker");
    }

    void LightStuff()
    {
        rand = Random.Range(0, 20);
        if (rand <= 0)
        {
            lightObj.GetComponent<Light>().enabled = false;
        }
        else
            lightObj.GetComponent<Light>().enabled = true;
    }

    IEnumerator Flicker()
    {
        yield return new WaitForSeconds(1f);
        LightStuff();
    }
}