using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                    SceneManager.LoadScene("Win");
                }
            }
        }
    }
}
