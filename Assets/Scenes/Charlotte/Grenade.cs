using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    public AudioClip explosionSound;
    public AudioClip grenadeBounce;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && !hasExploded)
            {
                Explode();
                hasExploded = true;
            }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        AudioSystem.PlaySoundEffect(explosionSound);

        //Returns array of all colliders overlapping sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);


        //Loop through each
        foreach (Collider nearbyObject in colliders)
        {
            //Search for rigidbody on each object
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            Health health = nearbyObject.GetComponent<Health>();

            if (health != null)
            {
                health.Damage(50f);

            }

            //If has rigidbody, add force from grenade
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSystem.PlaySoundEffect(grenadeBounce);
    }

}
