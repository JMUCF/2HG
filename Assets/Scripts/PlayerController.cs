using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody Rigid;
    public float MoveSpeed = 5f;
    public float RotationSpeed = 100f;
    public GameObject throwable;
    public float throwSpeed = 10f;
    public Camera playerCamera;

    void Update()
    {
        // Get input from the left joystick for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the player based on input
        Vector3 movement = transform.forward * verticalInput * MoveSpeed +
                           transform.right * horizontalInput * MoveSpeed;
        Rigid.MovePosition(transform.position + movement * Time.deltaTime);

        // Get input from the right joystick for camera rotation
        float rotateHorizontalInput = Input.GetAxis("RightStickHorizontal");
        float rotateVerticalInput = Input.GetAxis("RightStickVertical");

        // Rotate the player around the y-axis based on joystick input
        transform.Rotate(0, rotateHorizontalInput * RotationSpeed * Time.deltaTime, 0);

        // Rotate the camera vertically based on joystick input
        playerCamera.transform.Rotate(-rotateVerticalInput * RotationSpeed * Time.deltaTime, 0, 0);
        
        // Ensure the camera rotation is clamped to prevent over-rotation
        Vector3 cameraRotation = playerCamera.transform.localEulerAngles;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -90f, 90f);
        playerCamera.transform.localEulerAngles = cameraRotation;

        // Throw when the fire button is pressed
        if (Input.GetButtonDown("Fire1"))
            Throw();
    }

    void Throw()
    {
        // Offset distance in front of the player to spawn the throwable
        float offsetDistance = 1.0f;

        // Calculate the position in front of the player to spawn the throwable
        Vector3 spawnPosition = transform.position + transform.forward * offsetDistance;

        // Instantiate the throwable object at the calculated spawn position
        GameObject thrownObject = Instantiate(throwable, spawnPosition, Quaternion.identity);

        // Calculate the direction the player is looking
        Vector3 throwDirection = playerCamera.transform.forward;

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
}
