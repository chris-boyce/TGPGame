using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTurret : MonoBehaviour
{
    public float turretHealth = 100.0f;

    void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            turretHealth = turretHealth - 10.0f;

            if (turretHealth == 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }


    void Start()
    {
        
    }


    void Update()
    {

    }
}
