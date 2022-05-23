using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealthBox : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject Player;
    public Health Health;
    void Start()
    {
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthUp();
        }
    }
    private void HealthUp()
    {
        if(Health.currentHealth < 100)
        {
            Health.currentHealth += 50;
            Destroy(thisObject);
        }

    }

}
