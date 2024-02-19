using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    void OnTriggerEnter(Collider collision) //check if player reached exit #### ADD CONDITION CHECK FOR KEY PICKED UP
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You escaped the prison!");
            //play a sound effect here
            //bring up UI to go back to menu
            //deadText.SetActive(true);
            Time.timeScale = 0; //pause the game
        }
    }
}
