using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Pickup : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            AmmoUP();        
        }
    }
    private void AmmoUP()
    {
        Player.transform.Find("sniper_rifle").GetComponent<Sniper>().currentAmmoCount += 10;
        Player.transform.Find("machine_pistol_gun").GetComponent<MachinePistol>().currentAmmoCount += 200;
        Player.transform.Find("submachine_gun").GetComponent<Submachinegun>().currentAmmoCount += 200;
        Player.transform.Find("ak_machine_gun").GetComponent<AK>().currentAmmoCount += 150;
        Player.transform.Find("m16_machine_gun").GetComponent<M16>().currentAmmoCount += 150;
        Player.transform.Find("pump_action_shotgun").GetComponent<Shotgun>().currentAmmoCount += 20;
        Destroy(thisObject);
    }

}