using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
	[Header("Gravity Handling", order = 0)]
	[SerializeField]
	private Vector3 originOffset;
    [SerializeField]
    private float heightOffset = 1.0f; // Height of character.
    [SerializeField]
    private float heightDeadZone = 0.05f; // Acceptable height bounds before pullUpForce is added.
    [SerializeField]
    private float pullUpForce = 0.5f; // The applied force for when ground has been hit.

	[SerializeField]
	private bool grounded = true;

	[SerializeField]
    private bool forcedUp = false; // Helper to know when the player is still being pushed upwards after landing
	[SerializeField]
	private bool bounce; // used to discover if there is a bounce happening

    [SerializeField]
    private float maxHeightOffset = 0.2f; // Max distance before velocity must be stopped.
    [SerializeField]
    private float minFallSpeed = -0.8f; // Minimum falling speed when character has bounced from the floor.
    [SerializeField]
    private float maxFallSpeed = 2.0f; // Maximum speed when character has bounced from the floor.

	Vector3 pos;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

	private void FixedUpdate() {
		pos = transform.position + originOffset;
		HandleGravity();
	}

    /// <summary>
    /// Handles when to toggle gravity on and off for the player.
    /// </summary>
    private void HandleGravity() {

        if (bounce && forcedUp) { // If player has bounced.
            // Clamp Y velocity
			Debug.Log("bounce && forcedUp");
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, minFallSpeed, maxFallSpeed), rb.velocity.z);
        }

        Color debugColor = Color.green;

        RaycastHit hit;

        if (Physics.Raycast(pos, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity)) {
            HandleCollision(hit);
        }

        Debug.DrawLine(pos, pos + new Vector3(0, -heightOffset), debugColor);
    }

    /// <summary>
    /// Handles what to do when the player has collided with an object beneath them.
    /// </summary>
    /// <param name="hit">RaycastHit</param>
    private void HandleCollision(RaycastHit hit)
    {
		float hitDist = Vector3.Distance(hit.point, pos);

		if (hitDist < heightOffset && !grounded) {
			Debug.Log("hitDist < heightOffset + heightDeadZone");

			rb.useGravity = false; // Stop gravity from effecting this object.
			grounded = true;


			if (hitDist <= maxHeightOffset && rb.velocity.y <= 0) { // Stop because we're about to move beyond the object.
				Debug.Log("hitDist <= maxHeightOffset && rb.velocity.y <= 0");
				rb.velocity = ZeroYVector(rb.velocity);
			}

			if (hitDist < heightOffset - heightDeadZone) {
				if (rb.velocity.y < maxFallSpeed) {
					Debug.Log("rb.velocity.y < maxFallSpeed");
					rb.AddForce(Vector3.up * pullUpForce, ForceMode.VelocityChange);
					forcedUp = true;
				}
				return;
			}

			if (forcedUp && !bounce) {
				Debug.Log("forcedUp && !bounce");

				bounce = true;
				forcedUp = false;
			}

			if (rb.velocity.y > 0 && bounce && forcedUp) {
				Debug.Log("rb.velocity.y > 0 && bounce && forcedUp");
				rb.velocity = ZeroYVector(rb.velocity);
				forcedUp = false;
				bounce = false;
			}
			
		} else {
			grounded = false;
			rb.useGravity = true;
		}
	}

    /// <summary>
    /// Zeroes the Y axis on a vector
    /// </summary>
    /// <param name="vec"></param>
    /// <returns>Passed Vector with a 0 on Y.</returns>
    private Vector3 ZeroYVector(Vector3 vec) {
        return new Vector3(vec.x, 0, vec.z);
    }
}
