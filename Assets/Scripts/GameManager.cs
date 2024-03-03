using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the player has a pickup object component
            PickupObject pickupObject = other.gameObject.GetComponent<PickupObject>();
            if (pickupObject != null)
            {
                // Check if the key amount is greater than zero
                if (pickupObject.keyAmount > 0)
                {
                    Debug.Log("You escaped the prison! You win!");
                    // Additional actions you want to take upon winning
                }
                else
                {
                    Debug.Log("You don't have enough keys to escape!");
                    // Additional actions you want to take if the player doesn't have enough keys
                }
            }
        }
    }
}
