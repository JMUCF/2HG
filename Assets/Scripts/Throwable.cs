using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision)
	///This function will check when the throwable collides with something and create an area of sound that the enemy will be attracted to
	///It will also delete the throwable once collision happens so they dont just fill up the scene
	///Attach this script to the throwable prefab when ready
    {
		
	}
}
