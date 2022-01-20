using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Settings related to input methods and character movement.
	[Header("Input Settings")]
	[SerializeField]
	private bool mouseInput = false;
	[SerializeField]
	private float moveSpeed = 3.0f;
	[SerializeField]
	private Vector2 inputDeadZone = new Vector2(0.2f, 0.2f);
	[SerializeField]
	private float maxSpeed = 2.0f;
	[SerializeField]
	private float slowSpeed = 0.9f;
	
	// Settings related to the player camera.
	[Header("Camera Settings")]
	[SerializeField]
	private Camera cam;
	[SerializeField]
	private GameObject failSafePrefab; // spawn camera prefab just incase a cam does not exist.
	[SerializeField]
	private bool smoothCam = true;
	[SerializeField]
	private float camSmoothSpeed = 1.0f;
	[SerializeField]
	private float heightOffset = 8.0f;
	[SerializeField]
	private float distanceOffset = 6.0f; // Inverted.
	[SerializeField]
	private Vector3 angleOffset;
	
	private Rigidbody rb;
	private bool xInputPressed = false;
	private bool yInputPressed = false;

	Vector3 rbVec; // Rigidbody velocity with a 0 on y axis.

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		if (!cam) {
			var cameraSpawn = Instantiate(failSafePrefab);
			cam = cameraSpawn.GetComponent<Camera>();
		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		rbVec = new Vector3(rb.velocity.x, 0, rb.velocity.z);

		UpdatePlayerInput();
		UpdateCameraPos();
		ConstrainVelocity(); // Limits velocity of the player
	}

	/// <summary>
	/// Handles player input and applies movement.
	/// </summary>
	private void UpdatePlayerInput() {
		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Vertical");
		
		// Cursed but what we're doing is is rounding the direction of the camera's rotation.
		// It rounds it to prevent the normal being 0.7 and only giving the player 70% of the speed
		// based on the angle.
		Vector3 camDirX = new Vector3(Mathf.Round(cam.transform.right.normalized.x), 0, Mathf.Round(cam.transform.right.normalized.z));
		Vector3 camDirY = new Vector3(Mathf.Round(cam.transform.forward.normalized.x), 0, Mathf.Round(cam.transform.forward.normalized.z));

		if (xInput > inputDeadZone.x || xInput < -inputDeadZone.x) {
			if (rbVec.x > -maxSpeed || rbVec.x < maxSpeed) {
				rb.AddForce(camDirX * (xInput * moveSpeed), ForceMode.VelocityChange); // Apply motion based on the camera's direction.
				xInputPressed = true;
			}
		} else {
			xInputPressed = false;
		}

		if (yInput > inputDeadZone.y || yInput < -inputDeadZone.y) {
			if (rbVec.y > -maxSpeed || rbVec.y < maxSpeed) {
				rb.AddForce(camDirY * (yInput * moveSpeed), ForceMode.VelocityChange); // Apply motion based on the camera's direction.
				yInputPressed = true;
			}
        } else {
			yInputPressed = false;
		}

		// If there is no input on either button press
		if (!xInputPressed && !yInputPressed) {
			if (rbVec.magnitude > 0.005 || rbVec.magnitude < 0.005) { // If the speed is so little.
				rb.velocity = new Vector3(rb.velocity.x * slowSpeed, rb.velocity.y, rb.velocity.z * slowSpeed);
			} else {
				rb.velocity = Vector3.zero; // IT'S TIME TO STOP
			}
		}

	}

	/// <summary>
	/// Handles camera movement and camera placement + angle.
	/// </summary>
	private void UpdateCameraPos() {
		// result position of where to put the camera.
		Vector3 endPos = new Vector3(transform.position.x,
									transform.position.y + heightOffset,
									transform.position.z + distanceOffset);

		// If smooth cam is enabled, slerp the way to victory, if not, just set it to the endpos.
		cam.transform.position = smoothCam ?
			Vector3.Lerp(cam.transform.position, endPos, camSmoothSpeed * Time.deltaTime) :
			endPos;
		
		cam.transform.rotation = Quaternion.Euler(angleOffset.x, angleOffset.y, angleOffset.z);

	}

	/// <summary>
	/// Constrains the velocity onto the maxSpeed for X and Z.
	/// </summary>
	private void ConstrainVelocity() {

		if (rbVec.magnitude > maxSpeed) { // If there is movement in the X and Z higher than the maxSpeed.
			rbVec = rb.velocity.normalized; // reset the variable to just the normalised speed.
			rb.velocity = new Vector3(rbVec.x * maxSpeed, rb.velocity.y * 1, rbVec.z * maxSpeed); // Make sure Y is always going to be at a normal of 1.
		}
	}

}
