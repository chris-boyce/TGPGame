using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
	[Header("Ragdoll settings (Only used if ragdoll prefab is used)")]
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
	public GameObject CoinPrefab;

	private bool isDead;
	private GameObject ragdoll;

	// Droppable items on death.
	[Header("Droppable Items (Only used if tag is Enemy)")]
	[SerializeField]
	GameObject[] spawnDropablePrefab;
	[SerializeField]
	float spawnDropablePercentage = 0.05f;

	[Header("Health Values")]
	public float health;
	[SerializeField]
	public float currentHealth;
	//public Slider healthBarSlider
	//public GameObject slider;
	//public GameObject healthbarObject;

	public event System.Action OnDeath; // Wave Call depends on this script being run due to the Events System *Chris*

	void Start()
	{
		currentHealth = health;

		if (usePlayerController)
		{
			playerController = gameObject.GetComponent<PlayerController>();
		}
	}

	private void Update()
	{
		//healthBarSlider.value = currentHealth;

		if (!usePlayerController)
		{
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
		Debug.Log("Die Has Run");
		if(gameObject.CompareTag("Player"))
        {
			SceneManager.LoadScene("GameOver");
			Debug.Log("PLayer Dead");
        }


		if (gameObject.CompareTag("Enemy"))
		{
			if (Random.value < spawnDropablePercentage)
			{
				Instantiate(spawnDropablePrefab[Random.Range(0, spawnDropablePrefab.Length)]  , transform.position + new Vector3(0, 1, 0), transform.rotation);
			}
			if (Random.value < 0.2)
			{
				Instantiate(CoinPrefab, transform.position + new Vector3(0, 1, 0) , transform.rotation);
			}
			
			//OnDeath?.Invoke();

		}
		if (!ragdollPrefab) { Destroy(gameObject); return; }

		Destroy(this.gameObject);

		if(isDead == false)
        {
			OnDeath?.Invoke();
			ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation, transform.parent);
			isDead = true;
		}
		

		Destroy(ragdoll, 5f);

		CopyModelPos ragdollScript = ragdoll.GetComponent<CopyModelPos>();
		ragdollScript.ApplyRagdoll(rootPart.transform, ragdollScript.root);
		ragdollScript.vel = usePlayerController ? playerController.GetVelocity() : velManual;

		ragdoll.SetActive(true);
		ragdollScript.StartTimer(5, usePlayerController);

		foreach (var obj in disableList)
		{
			obj.SetActive(false); // Disable the model.
		}
	}
	public void GainHealth()
    {
		health = health + 50;
		currentHealth = health;
    }

}