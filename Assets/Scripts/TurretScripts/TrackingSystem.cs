using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject target;
    Vector3 lastPosition = Vector3.zero;
    Quaternion lookRotation;

    public GameObject bullet;
    public GameObject gun;
    public Transform bulletPosition;
    public ParticleSystem muzzle;
    public float fireRate = 5.0f;
    public float maxDistance = 10.0f;
    private float nextFire = 2.0f;    


    void Start()
    {
        gun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject.CompareTag("Enemy"))
        {            
            if (lastPosition != target.transform.position)
            {
                lastPosition = target.transform.position;
                lookRotation = Quaternion.LookRotation(lastPosition - transform.position);
            }

            if (transform.rotation != lookRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, speed * Time.deltaTime);
            }
                           
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Shoot();
        }
    }

    bool SetTarget(GameObject _target)
    {
        if(!target)
        {
            return false;
        }

        //target = _target;

        return true;
    }

    void Shoot()
    {        
        nextFire = Time.time + 1f / fireRate;
        Instantiate(bullet, bulletPosition.transform.position, bulletPosition.transform.rotation);
        muzzle.Play();
    }
}
