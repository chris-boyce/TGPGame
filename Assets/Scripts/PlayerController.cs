using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Input Settings")]
	[SerializeField]
	bool mouseInput = false;
	[SerializeField]
	float moveSpeed = 3.0f;
	[SerializeField]
	Vector2 inputDeadZone = new Vector2(0.2f, 0.2f);
	[SerializeField]
	float slowSpeed = 0.9f;

	[Header("Camera Settings")]
	[SerializeField]
	private Camera cam;
	[SerializeField]
	private float camSmoothSpeed = 1.0f;
	[SerializeField]
	private float heightOffset = 8.0f;
	[SerializeField]
	private float distanceOffset = 6.0f; // Inverted.
	[SerializeField]
	private Vector3 angleOffset;
	
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		UpdatePlayerInput();
		UpdateCameraPos();
	}

	private void UpdatePlayerInput() {
		Debug.Log("forward: " + cam.transform.forward.normalized);
		Debug.Log("right: " + cam.transform.right.normalized);
		Debug.Log("up: " + cam.transform.up.normalized);
		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Vertical");
		
		Vector3 camDirX = new Vector3(cam.transform.right.normalized.x, 0, cam.transform.right.normalized.z);
		Vector3 camDirY = new Vector3(cam.transform.right.normalized.x, 0, cam.transform.right.normalized.z);

		if (xInput > inputDeadZone.x || xInput < -inputDeadZone.x) {
			rb.AddForce(camDirX * (xInput * moveSpeed));

		} else {
			if (rb.velocity.x > 0.05 || rb.velocity.x < 0.05) {
				rb.velocity = rb.velocity * slowSpeed;
			} else {
				rb.velocity = Vector3.zero;
			}
		}

		if (yInput > inputDeadZone.y || yInput < -inputDeadZone.y) {
			rb.AddForce(cam.transform.forward.normalized * (yInput * moveSpeed));

		} // else {
			//if (rb.velocity.z > 0.05 || rb.velocity.z < 0.05) {
			//	rb.velocity = cam.transform.forward.normalized * slowSpeed;
			//} else {
			//	rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
			//}
		// }
	}

	private void UpdateCameraPos() {
		Vector3 endPos = new Vector3(transform.position.x,
									transform.position.y + heightOffset,
									transform.position.z + distanceOffset);

		cam.transform.position = Vector3.Lerp(cam.transform.position, endPos, camSmoothSpeed * Time.deltaTime);
		cam.transform.rotation = Quaternion.Euler(angleOffset.x, angleOffset.y, angleOffset.z);
	}

}
