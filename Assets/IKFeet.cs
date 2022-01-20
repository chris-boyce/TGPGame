using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFeet : MonoBehaviour {
	[SerializeField]
	private float footDistance = 0.0f;
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

	Rigidbody rb;

	// Start is called before the first frame update
    void Start()
    {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		root = player.transform;
		rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

		transform.position = currentPos;

		if (Physics.Raycast(root.position + (root.right * footDistance), Vector3.down, out RaycastHit hit)) {
			if (Vector3.Distance(newPos, hit.point) > stepDistance) { newPos = hit.point; lerp = 0; }
		}

		if(lerp < 1) {
			Vector3 footPos = Vector3.Lerp(oldPos, newPos, lerp);
			footPos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

			currentPos = footPos;
			lerp += (speed + rb.velocity.magnitude) * Time.deltaTime;
		} else {
			oldPos = newPos;
		}
	}
}
