using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	[SerializeField]
	GameObject ragdollPrefab; // Jon ADD: Adds in dead ragdolls.
	[SerializeField]
	GameObject rootPart;
	[SerializeField]
	GameObject[] disableList; // list of objects to disable when dying.
	[SerializeField]
	bool usePlayerController;
	PlayerController playerController;
	Vector3 oldPos; // Used only if player controller is not used.
	Vector3 velManual; // Manually calculated velocity.


	// Droppable items on death.
	[SerializeField]
	GameObject spawnDropablePrefab;
	[SerializeField]
	float spawnDropablePercentage = 0.05f;

	public float health = 100f;
	[SerializeField]
	public float currentHealth;
	//public Slider healthBarSlider;
	//public GameObject slider;
	//public GameObject healthbarObject;

	public event System.Action OnDeath; // Wave Call depends on this script being run due to the Events System *Chris*


	void Start()
	{
		currentHealth = health;

		if (usePlayerController) {
			playerController = gameObject.GetComponent<PlayerController>();
		}
	}

	private void Update()
	{
		//healthBarSlider.value = currentHealth;

		if (!usePlayerController) {
			velManual = (transform.position - oldPos);
			oldPos = transform.position;
		}
	}

	public void Damage(float damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			Die();
		}
	}
	void Die()
	{
		// Jon EDIT: Changes the way player dies to apply a ragdoll afterwards.

		//Debug.Log("Dead"); 
		//currentHealth = health;
		//Destroy(gameObject);
		//Destroy(healthbarObject);
		//Destroy(slider);

		if (!ragdollPrefab) { Destroy(gameObject); return; }

		if (OnDeath != null) {
			if(gameObject.CompareTag("Enemy"))	OnDeath();
			if(Random.value < spawnDropablePercentage) {
				Instantiate(spawnDropablePrefab, transform.position, transform.rotation, transform.parent.parent);
			}
		}

		GameObject ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation, transform.parent);
		CopyModelPos ragdollScript = ragdoll.GetComponent<CopyModelPos>();
		ragdollScript.ApplyRagdoll(rootPart.transform, ragdollScript.root);
		ragdollScript.vel = usePlayerController ? playerController.GetVelocity() : velManual;

		ragdoll.SetActive(true);
		ragdollScript.StartTimer(5, usePlayerController);

		foreach (var obj in disableList) {
			obj.SetActive(false); // Disable the model.
		}
	}

	
}