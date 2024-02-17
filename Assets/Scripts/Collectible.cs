using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	#region "Variables"
    public GameObject itemCollected;
    public bool itemCollectedBool = false;
	
	public GameObject exitDoor;
	#endregion
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Item collected!");
            itemCollected.SetActive(true);
            itemCollectedBool = true;
            //make coroutine to stop text after 2 seconds
            //play a sound effect here
            Destroy(this.gameObject); //destroy the collectible
            //update gameManager to know item was picked up
			Destroy(exitDoor);
        }
    }
}
