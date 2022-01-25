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
        Destroy(thisObject);
    }
}