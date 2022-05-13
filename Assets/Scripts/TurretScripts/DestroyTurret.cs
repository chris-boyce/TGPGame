using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTurret : MonoBehaviour
{
    public float turretHealth = 100.0f;
    public GameObject turret;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(10.0f);

            if (turretHealth == 0.0f)
            {
                Destroy(turret);
            }
        }
    }

    void takeDamage(float health)
    {
        turretHealth = turretHealth - health;
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }


    void Update()
    {

    }
}
