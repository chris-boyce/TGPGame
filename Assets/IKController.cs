using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour {

	[SerializeField]
	private Transform root;
	[SerializeField]
	private float footOffset = 0.1f;

	[SerializeField]
	private Transform leftFoot;
	[SerializeField]
	private Transform leftFootTarget;
	bool lFootUp;

	[SerializeField]
	private Transform rightFoot;
	[SerializeField]
	private Transform rightFootTarget;
	bool rFootUp;

	[Range(0.0f, 10.0f)]
	private float stepDistance = 0.5f;
	[SerializeField]
	[Range(0.0f, 2.0f)]
	private float stepHeight = 0.4f;
	[SerializeField]
	private float speed = 1.0f;


	// Start is called before the first frame update
	void Start()
    {

	}

    // Update is called once per frame
    void Update() {
		if (rFootUp) {
			Vector3.Lerp(rightFoot.position, rightFootTarget.position, speed);
		}

		if (lFootUp) {
			Vector3.Lerp(leftFoot.position, leftFootTarget.position, speed * Time.deltaTime);
		}

		if (Vector3.Distance(leftFoot.position, leftFootTarget.position) > stepDistance) {
			if (!rFootUp) {
				lFootUp = true;
			}
		} else {
			lFootUp = false;
		}

		if (Vector3.Distance(rightFoot.position, rightFootTarget.position) > stepDistance) {
			if (!lFootUp) {
				rFootUp = true;
			}
		} else {
			rFootUp = false;
		}

		if (Physics.Raycast(root.position + (root.right * rightFootTarget.position.x), Vector3.down, out RaycastHit rHit)) {
			rightFootTarget.position = new Vector3(rightFootTarget.position.x, rHit.point.y, rightFootTarget.position.z);
		}

		if (Physics.Raycast(root.position + (root.right * leftFootTarget.position.x), Vector3.down, out RaycastHit lHit)) {
			leftFootTarget.position = new Vector3(leftFootTarget.position.x, lHit.point.y, leftFootTarget.position.z);
		}


	}

}
