using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealthBox : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
        Player.GetComponent<Health>().currentHealth += 50; 
        Destroy(thisObject);
    }

}
