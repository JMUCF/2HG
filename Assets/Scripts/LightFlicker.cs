using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public GameObject lightObj;
    private float rand;

    void Start()
    {
        Flicker();
    }

    void Flicker()
    {
        for(int i = 0; i < 100; i++)
        {
            StartCoroutine(waitOneSecond());
            rand = Random.Range(0, 10);
            //Debug.Log(rand);
            if (rand <= 4)
            {
                lightObj.GetComponent<Light>().enabled = false;
            }
            else
                lightObj.GetComponent<Light>().enabled = true;
        }
    }

    IEnumerator waitOneSecond()
    {
        Debug.Log("Started coroutine to wait 1 second");
        yield return new WaitForSeconds(1);
        Debug.Log("Waited one second");
    }
}