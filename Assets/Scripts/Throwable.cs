using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public GameObject soundBox;
	
	void OnCollisionEnter(Collision collision)
    {
        GameObject soundPoint = Instantiate(soundBox, this.transform.position, Quaternion.identity); //create the sound object at the collision point of throwable
        Destroy(this.gameObject); //destroy throwable
	}
}
