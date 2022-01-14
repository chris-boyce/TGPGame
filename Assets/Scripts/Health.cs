using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

	public float health = 100f;
	[SerializeField]
	private float currentHealth;
	public Slider healthBarSlider;
	public GameObject slider;
	public GameObject healthbarObject;


	void Start()
	{
		currentHealth = health;
	}

	private void Update()
	{
		healthBarSlider.value = currentHealth;
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
		Debug.Log("Dead");
		currentHealth = health;
		Destroy(gameObject);
		Destroy(healthbarObject);
		Destroy(slider);
       
	}
}