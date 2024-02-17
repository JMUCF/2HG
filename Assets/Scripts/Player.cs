using UnityEngine;
 
public class Player : MonoBehaviour
{
 
    #region "Variables"
    public Rigidbody Rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
	public GameObject throwable;
	
	public float throwSpeed = 10f; // Adjust this value to control the initial speed of the throw
	public Vector3 gravity = Physics.gravity; // Use Unity's built-in gravity
	public Camera playerCamera; // Reference to the player's camera
	#endregion

	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

		// Rotate the player around the y-axis based on mouse input
		Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, mouseX, 0)));

		// Calculate the new rotation for looking vertically
		Quaternion camRotation = playerCamera.transform.rotation * Quaternion.Euler(-mouseY, 0, 0);

		// Apply the new rotation to the camera
		playerCamera.transform.rotation = camRotation;

		// Move the player based on input
		Vector3 movement = transform.forward * Input.GetAxis("Vertical") * MoveSpeed +
			transform.right * Input.GetAxis("Horizontal") * MoveSpeed;
		Rigid.MovePosition(transform.position + movement);

		if (Input.GetKeyDown("space"))
			Throw();
	}
	
	void Throw()
	{
		// Offset distance in front of the player to spawn the throwable
		float offsetDistance = 1.0f; // Adjust this value as needed

		// Calculate the position in front of the player to spawn the throwable
		Vector3 spawnPosition = this.transform.position + this.transform.forward * offsetDistance;

		// Instantiate the throwable object at the calculated spawn position
		GameObject thrownObject = Instantiate(throwable, spawnPosition, Quaternion.identity);

		// Calculate the direction the player is looking, including vertical component
		Vector3 throwDirection = playerCamera.transform.forward;

		// Get the Rigidbody component of the instantiated object
		Rigidbody rb = thrownObject.GetComponent<Rigidbody>();

		// Check if the Rigidbody component exists
		if (rb != null)
		{
			// Calculate the initial velocity based on throwSpeed and throwDirection
			Vector3 initialVelocity = throwSpeed * throwDirection;

			initialVelocity += Rigid.velocity;

			rb.velocity = initialVelocity;
			rb.useGravity = true;
		}
		else
		{
			Debug.LogWarning("Rigidbody component not found on throwable object!");
		}
	}
}