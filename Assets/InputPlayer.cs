using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    public PauseMenu pauseMenu;

    PlayerControls controls;
    Vector2 move;
    Vector2 rotate;

    public Transform cameraTransform;

    public float MouseSensitivity;
    public float MoveSpeed;
    public Rigidbody Rigid;
    public GameObject throwable;
    public float throwSpeed = 10f;

    private PickupObject pickupObjectScript;
    private int hydrantAmount = 0;
    private int hydrantsUsed = 0;

    void Awake()
    {
        controls = new PlayerControls();
        pickupObjectScript = GetComponent<PickupObject>();

        controls.Gameplay.Throw.performed += ctx => Throw();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Look.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => rotate = Vector2.zero;

        controls.Gameplay.Pickup.performed += ctx => pickupObjectScript.Pickup();
    }

    void Update()
    {
        if (pauseMenu.GameIsPaused == false)
		{
            hydrantAmount = pickupObjectScript.hydrantAmount;

        #region controller movement
        // Movement
        Vector3 m = new Vector3(move.x, 0, move.y) * 10f * Time.deltaTime;
        Rigid.MovePosition(transform.position + m);

        // Camera rotation
        Vector2 r = new Vector2(rotate.x, -rotate.y) * 200f * Time.deltaTime;
        cameraTransform.Rotate(Vector3.right, r.y, Space.Self); // Rotate around the camera's local right axis (look up and down)
        transform.Rotate(Vector3.up, r.x, Space.World); // Rotate the player around the world up axis (look left and right)
        #endregion

        #region mouse & kb movement
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

		// Rotate the player around the y-axis based on mouse input
		Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, mouseX, 0)));

		// Calculate the new rotation for looking vertically
		Quaternion camRotation = cameraTransform.transform.rotation * Quaternion.Euler(-mouseY, 0, 0);

		// Apply the new rotation to the camera
		cameraTransform.transform.rotation = camRotation;

		// Move the player based on input
		Vector3 movement = transform.forward * Input.GetAxis("Vertical") * MoveSpeed + transform.right * Input.GetAxis("Horizontal") * MoveSpeed;
		Rigid.MovePosition(transform.position + movement);

		if (Input.GetKeyDown("space"))
			Throw();
        #endregion

        #region cameraClamp
        Vector3 cameraRotation = cameraTransform.transform.localEulerAngles;
        // Min/max angles for vertical rotation
        float minVerticalAngle = -40f;
        float maxVerticalAngle = 40f;
        float clampedXRotation = cameraRotation.x; // Calculate clamped vertical rotation
        if (clampedXRotation > 180f) // Convert to range -180 to 180
            clampedXRotation -= 360f;
        clampedXRotation = Mathf.Clamp(clampedXRotation, minVerticalAngle, maxVerticalAngle);
        // Assign clamped rotation back to camera
        cameraRotation.x = clampedXRotation;
        cameraRotation.y = 0;
        cameraRotation.z = 0;
        cameraTransform.transform.localEulerAngles = cameraRotation;
        #endregion
        }
    }

    void Throw()
    {
        if((hydrantAmount-hydrantsUsed) == 0 )
            return;
        // Offset distance in front of the player to spawn the throwable
        float offsetDistance = 1.0f;

        // Calculate the position in front of the player to spawn the throwable
        Vector3 spawnPosition = transform.position + transform.forward * offsetDistance;

        // Instantiate the throwable object at the calculated spawn position
        GameObject thrownObject = Instantiate(throwable, spawnPosition, Quaternion.identity);

        // Calculate the direction the player is looking
        Vector3 throwDirection = cameraTransform.transform.forward;

        // Get the Rigidbody component of the instantiated object
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();

        // Check if the Rigidbody component exists
        if (rb != null)
        {
            // Calculate the initial velocity based on throwSpeed and throwDirection
            Vector3 initialVelocity = throwSpeed * throwDirection + Rigid.velocity;

            rb.velocity = initialVelocity;
            rb.useGravity = true;
        }
        else
        {
            Debug.LogWarning("Rigidbody component not found on throwable object!");
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}