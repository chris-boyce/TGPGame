using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code is mostly credited from unity's prototype project for teaching character rigging with proceedural animation
// however I had to modify a lot of it to get it to function.

// 1: To setup. Click on the model and click animation rigging in the top left, click "setup rig".
// 2: Create 4 new game objects, 2 for the feet, 2 for the knees.
// 3: Assign this script to the feet and make sure that this is not a parent of the player object.
// 4: In the rig, create two new game objects and in each one add a "Two Bone IK constraint"
// 5: for the root, add the thigh bone for which side you want, mid is the shin bone, tip is the foot.
// 6: add the foot game object we created in step 2 into the "target" option
// 7: Add the knee into the "hint" function.
// 8: make sure all weights in the rig settings are set to 1. And you're good to go!

public class IKFeet : MonoBehaviour {
	
	[SerializeField]
	private float footDistance = 0.0f; // distance of the feet sideways, lets you do the splits or something idk.
	[SerializeField]
	private float forwardOffset = 0.3f; // how far the foot will extend out, gets inverted after every step.
	[SerializeField]
	[Range(0.0f, 10.0f)]
	private float stepDistance = 1.0f; // the max distance allowed between making steps.
	[SerializeField]
	[Range(0.0f, 2.0f)]
	private float stepHeight = 0.4f; // how high should the feet go while making a step.
	[SerializeField]
	private float forwardDistanceDivider = 8.5f; // the distance added by velocity for judging when to put the next foot is divided by this.
	[SerializeField]
	private float speed = 1.0f; // Speed of how fast the footstep is 

	[SerializeField]
	private Vector3 rotationOffset; // Applies a permanent offset to the rotation of the foot.

	[SerializeField]
	private Transform root; // player position
	private Rigidbody rb; // rigidbody of the player.
	[SerializeField]
	bool calcVelocity = false; // Used if no rigidbody is present to create a velocity.

	private Vector3 currentPos; // Current position of the foot.
	private Vector3 oldPos; // old position before the new position will overwrite it.
	private Vector3 newPos; // new position after the distance is greater between the currentpos and where the desired spot.
	private float lerp; // lerp value for smoothness.

	[SerializeField]
	private IKFeet oppositeFoot; // as the name implies. Opposite foot.

	// helpers for checking other feet.
	private bool invertFoot = true;
	public bool movingFoot = false;
	public bool finishedMoving = true;

	[SerializeField]
	Vector3 velocity; // velocity of the player. Used only when calcVelocity is true.
	Vector3 oldRootPos; // position of the root on the last frame.

	// Start is called before the first frame update
	void Start()
    {
		rb = root.GetComponent<Rigidbody>();
		if (rb == null) calcVelocity = true;
		currentPos = root.position + (-root.up * 0.8f);
    }

    // Update is called once per frame
    void FixedUpdate() {
		if(calcVelocity)	velocity = (root.position - oldRootPos);

		float magnitude;
		magnitude = calcVelocity ? velocity.sqrMagnitude : rb.velocity.sqrMagnitude;


		transform.position = currentPos;

		Quaternion rot = root.rotation;
		rot *= Quaternion.Euler(rotationOffset);
		transform.rotation = rot;

		// root position is the player.
		// player gets given an offset for the feet on the right and left.
		// gets an offset based on the location of the foot and velocity of the player.
		Vector3 pointSpeed = calcVelocity ? velocity.normalized : rb.GetRelativePointVelocity(root.position);

		Debug.DrawLine(root.position, root.position + pointSpeed, Color.blue);

		var distDivide = calcVelocity ? 1 : forwardDistanceDivider;

		Vector3 rootTrans = root.position + (root.right * footDistance) + (root.forward * (invertFoot ? forwardOffset : -forwardOffset)) + (new Vector3(pointSpeed.x, 0, pointSpeed.z) / distDivide);

		Debug.DrawLine(root.position, rootTrans, Color.green);

		// fire a ray down to the floor.
		// if the distance of newPos and the ray is larger than 0.3
		// set invertfoot.
		// newpos is equal to the raycast location.
		// set lerp to 0.

		if (Physics.Raycast(rootTrans, Vector3.down, out RaycastHit hit)) {
			if (Vector3.Distance(newPos, hit.point) > stepDistance) {
				if (!oppositeFoot.movingFoot && !movingFoot) {
					newPos = hit.point;
					movingFoot = true;
					lerp = 0;
				} else {
					oldPos = hit.point;
					movingFoot = false;
				}
			} else {
				movingFoot = false;
			}
		}

		// if lerp is less than 1,
		// foot position is the lerped position of the oldpos, then the new pos using the value of lerp.
		// set the y of footpos to be a sin of lerp multiplied by pi to give the 0 to 1 value, and height being the actual height of where it will reach.

		// set the currentPos to the footpos.
		// magnitude stuff
		// add speed + magnitude times by the deltatime to lerp (could this be going over 1 if the magnitude gets so high causing the missing steps?
		//
		// if lerp is more than 1, set the oldPos to newPos.
		if (lerp < 1) {
			Vector3 footPos = Vector3.Lerp(oldPos, newPos, lerp);

			if (magnitude < 0) { // if the magnitude is ever negative, set it to positive.
				magnitude = -magnitude;
			}

			footPos.y += Mathf.Sin((lerp + magnitude) * Mathf.PI) * stepHeight;

			
			currentPos = footPos;
			movingFoot = true;
			lerp += speed * Time.deltaTime;
			
		} else {
			oldPos = newPos;
			invertFoot = !invertFoot;
			finishedMoving = true;
			movingFoot = false;
		}

		oldRootPos = root.position;
	}
}
