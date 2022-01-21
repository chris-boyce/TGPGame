using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFeet : MonoBehaviour {
	[SerializeField]
	private float footDistance = 0.0f;
	[SerializeField]
	private float forwardOffset = 0.3f;
	[SerializeField]
	[Range(0.0f, 10.0f)]
	private float stepDistance = 1.0f;
	[SerializeField]
	[Range(0.0f, 2.0f)]
	private float stepHeight = 0.4f;
	[SerializeField]
	private float speed = 1.0f;

	Transform root;
	Vector3 currentPos;
	Vector3 oldPos;
	Vector3 newPos;
	float lerp;

	private bool invertFoot = true;
	private bool movingFoot = true;

	[SerializeField]
	IKFeet oppositeFoot;
	Rigidbody rb;

	// Start is called before the first frame update
    void Start()
    {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		root = player.transform;
		rb = player.GetComponent<Rigidbody>();
		currentPos = root.position + (-root.up * 0.8f);
    }

    // Update is called once per frame
    void Update() {
		transform.position = currentPos;
		transform.rotation = root.rotation;
		Debug.DrawRay(currentPos, Vector3.up, Color.green);


		Vector3 rootTrans = root.position + (root.right * footDistance) + (root.forward * (invertFoot ? forwardOffset : -forwardOffset));

		// root position is the player.
		// player gets given an offset for the feet on the right and left.
		// gets an offset based on the location of the foot.

		Debug.DrawRay(rootTrans, Vector3.down, Color.cyan);

		// fire a ray down to the floor.
		// if the distance of newPos and the ray is larger than 0.3
		// set invertfoot.
		// newpos is equal to the raycast location.
		// set lerp to 0.

		if (Physics.Raycast(rootTrans, Vector3.down, out RaycastHit hit)) {
			if (Vector3.Distance(newPos, hit.point) > stepDistance) {
				newPos = hit.point;
				movingFoot = true;
				lerp = 0;
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
			float magnitude = rb.velocity.magnitude;
			if (magnitude < 0) { // if the magnitude is ever negative, set it to positive.
				magnitude = -magnitude;
			}

			Vector3 footPos = Vector3.Lerp(oldPos, newPos, lerp + magnitude);
			footPos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

			Debug.DrawRay(footPos, Vector3.up, Color.yellow);
			
			currentPos = footPos;

			invertFoot = !invertFoot;
			lerp += speed * Time.deltaTime;
			
		} else {
			Debug.DrawRay(newPos, Vector3.up, Color.magenta);
			Debug.DrawRay(oldPos, Vector3.up, Color.black);
			oldPos = newPos;
			movingFoot = false;
		}
	}
}
