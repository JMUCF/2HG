using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickupObject : MonoBehaviour
{
    public Transform playerCamera; // Reference to the player's camera
    public float pickupDistance = 3f; // Maximum distance to pick up the object
    public float pickupAngle = 45f; // Angle within which the player can pick up objects
    public KeyCode pickupKey = KeyCode.E; // Key to pick up the object
    public TMP_Text pickupMessage; // UI text to display pickup message
    public int hydrantAmount = 0;
    public int keyAmount = 0;

    private GameObject objectToPickup; // Reference to the object to pick up
    private bool isLookingAtObject = false; // Flag to track if the player is looking at a pickable object

    private AudioSource playerAudioSource;

    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // Check if the player is looking at an object to pick up
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickupDistance))
        {
            // Check if the object to pick up matches the specific prefab and is within pickup angle
            if (hit.collider.CompareTag("hydrant") && Vector3.Angle(playerCamera.forward, hit.point - playerCamera.position) <= pickupAngle)
            {
                // Store the object to pick up
                objectToPickup = hit.collider.gameObject;
                isLookingAtObject = true;
                // Display pickup message
                pickupMessage.text = "Press E to pick up";
            }
            else if (hit.collider.CompareTag("key") && Vector3.Angle(playerCamera.forward, hit.point - playerCamera.position) <= pickupAngle)
            {
                // Store the object to pick up
                objectToPickup = hit.collider.gameObject;
                isLookingAtObject = true;
                // Display pickup message
                pickupMessage.text = "Press E to pick up";
            }
            else
            {
                isLookingAtObject = false;
                // Hide pickup message
                pickupMessage.text = "";
            }
        }
        else
        {
            isLookingAtObject = false;
            // Hide pickup message
            pickupMessage.text = "";
        }

        // Check if the player presses the pickup key while looking at an object
        if (isLookingAtObject && Input.GetKeyDown(pickupKey))
        {
            // Pick up the object
            Pickup();
        }
    }

    public void Pickup()
    {
        if(objectToPickup.CompareTag("hydrant"))
            hydrantAmount++;
        if(objectToPickup.CompareTag("key"))
            keyAmount++;

        //play pickup audio
        playerAudioSource.Play();

        // Destroy the object that was picked up
        Destroy(objectToPickup);
        // Hide pickup message after picking up
        pickupMessage.text = "";
    }
}
