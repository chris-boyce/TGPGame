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
        if (other.CompareTag("Player"))
        {
            // HealthUP();
             AmmoUP();
            //int randomNumber = Random.Range(0, 2);

            //if (randomNumber == 0)
            //{
            //    HealthUP();
            //}
            //if (randomNumber == 1)
            //{
            //    AmmoUP();
            //}
        }
    }

    private void HealthUP()
    {
        // Player.GetComponentInChildren<Health>();
        // Player.transform.GetChild(1).GetComponent<Health>().currentHealth += 25;
        Player = Player.gameObject.transform.Find("PlayerObject").gameObject;
        Player.GetComponent<Health>().currentHealth += 25;
     
        Destroy(pickupObject);
    }

    private void AmmoUP()
    {
        //Player = Player.gameObject.transform.Find("tempGun").gameObject;
       Player.gameObject.transform.Find("tempGun").GetComponent<Gun>().ammoCount += 100;
        Destroy(pickupObject);
    }
}