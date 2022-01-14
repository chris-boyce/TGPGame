using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
	
	[Header("Camera Settings")] 
	[SerializeField]
	private Camera cam;
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

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		ConstrainVelocity();
		UpdatePlayerInput();
		UpdateCameraPos();
	}

	private void ConstrainVelocity()
    {
		if(rb.velocity.magnitude > maxSpeed)
        {
			rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

	private void UpdatePlayerInput() {
		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Vertical");
		
		Vector3 camDirX = new Vector3(Mathf.Round(cam.transform.right.normalized.x), 0, Mathf.Round(cam.transform.right.normalized.z));
		Vector3 camDirY = new Vector3(Mathf.Round(cam.transform.forward.normalized.x), 0, Mathf.Round(cam.transform.forward.normalized.z));

		if (xInput > inputDeadZone.x || xInput < -inputDeadZone.x) {
			rb.AddForce(camDirX * (xInput * moveSpeed));
			xInputPressed = true;
		} else {
			xInputPressed = false;
		}

		if (yInput > inputDeadZone.y || yInput < -inputDeadZone.y) {
			rb.AddForce(camDirY * (yInput * moveSpeed));
			yInputPressed = true;
        } else {
			yInputPressed = false;
		}

		if (!xInputPressed && !yInputPressed) {
			if (rb.velocity.magnitude > 0.05 || rb.velocity.magnitude < 0.05) {
				rb.velocity = rb.velocity * slowSpeed; 
			} else {
				rb.velocity = Vector3.zero;
			}
		}

	}

	private void UpdateCameraPos() {
		Vector3 endPos = new Vector3(transform.position.x,
									transform.position.y + heightOffset,
									transform.position.z + distanceOffset);

		cam.transform.position = smoothCam ?
			Vector3.Lerp(cam.transform.position, endPos, camSmoothSpeed * Time.deltaTime) :
			endPos;
		

		cam.transform.rotation = Quaternion.Euler(angleOffset.x, angleOffset.y, angleOffset.z);

	}

}
