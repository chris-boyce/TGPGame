using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyModelPos : MonoBehaviour
{

	public Transform root;
	public Vector3? vel = null;


	public void ApplyRagdoll(Transform source, Transform part) {
		part.localPosition = source.localPosition;
		part.localRotation = source.localRotation;

		for (int i = 0; i < source.childCount; i++) {


			Transform child = part.GetChild(i); // this is a child object of the ragdoll part we have.
			Transform childSource = source.GetChild(i); // this is the same ragdoll part of the reference we're working with aka, source.

			if(vel.HasValue) {
				Rigidbody childrb = child.GetComponent<Rigidbody>();
				if (childrb) {
					childrb.velocity = (Vector3)vel;
				}
			}
			if(child && childSource) {
				ApplyRagdoll(childSource, child);
			}
		}
	}

	public void StartTimer(int timer, bool player) {
		Debug.Log("startTimer called");
		StartCoroutine(DeleteBody(timer, player));
	}

	public IEnumerator DeleteBody(int timer, bool player) {
		if (!player) {
			Debug.Log("!player, " + timer + ". Calling wait");
			yield return new WaitForSeconds(timer);
			Debug.Log("Calling wait finished");
			Destroy(transform.parent.gameObject);
		} else {
			Debug.Log("player, " + timer + ". Calling wait");
			yield return new WaitForSeconds(timer);
			GameObject.FindGameObjectWithTag("SceneSwitch").GetComponent<SceneSwitcher>().LoadSingleScene(10);
			Debug.Log("Calling wait finished");

		}
	}

}
