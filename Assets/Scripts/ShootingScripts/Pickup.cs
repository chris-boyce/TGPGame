using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Pickup : MonoBehaviour
{
    public GameObject pickupObject;
    public GameObject Player;
    
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
        if (other.CompareTag("Pickup"))
        {

            int randomNumber = Random.Range(0, 101);

            if (randomNumber <= 50)
            {
                HealthUP();
            }
            if (randomNumber >50)
            {
                AmmoUP();
            }
            Destroy(other.gameObject);
            Console.WriteLine(randomNumber);
        }
    }

    private void HealthUP()
    {
        Player.transform.Find("PlayerObject").GetComponent<Health>().currentHealth += 25;
    }

    private void AmmoUP()
    {
        Player.transform.Find("PlayerSniper").GetComponent<Sniper>().currentAmmoCount += 20;
        Player.transform.Find("PlayerMachinePistol").GetComponent<MachinePistol>().currentAmmoCount += 20;
        Destroy(pickupObject);
    }
}