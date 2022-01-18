using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickupObject;
    public GameObject Player;
    private GameObject playerObject;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int randomNumber = Random.Range(0, 2);

            if(randomNumber == 0)
            {
                HealthUP();
            }
            if (randomNumber == 1)
            {
                AmmoUP();
            }
        }
    }

    private void HealthUP()
    {
        Player = Player.gameObject.transform.Find("PlayerObject").gameObject;
        Health health = Player.GetComponent<Health>();
        health.currentHealth += 25;
        Destroy(pickupObject);
    }

    private void AmmoUP()
    {
        Console.WriteLine("Ammo");
        Destroy(pickupObject);
    }



}
