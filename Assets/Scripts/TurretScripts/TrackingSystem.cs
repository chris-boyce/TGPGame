using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject target = null;
    Vector3 lastPosition = Vector3.zero;
    Quaternion lookRotation;

    public GameObject bullet;
    public GameObject gun;
    public Transform bulletPosition;
    public ParticleSystem muzzle;
    public float fireRate = 15.0f;
    private float nextFire = 0.0f;


    void Start()
    {
        gun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = (target.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(a, transform.forward);

        if(target)
        {
            if(lastPosition != target.transform.position)
            {
                lastPosition = target.transform.position;
                lookRotation = Quaternion.LookRotation(lastPosition - transform.position);
            }

            if(transform.rotation != lookRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, speed * Time.deltaTime);
            }

            if(dot != 0)
            {
                Shoot();
                //return;
            }
            else
            {
                Shoot();
            }
        }
    }

    bool SetTarget(GameObject _target)
    {
        if(!target)
        {
            return false;
        }

        target = _target;

        return true;
    }

    void Shoot()
    {
        muzzle.Play();
        nextFire = Time.time + 1f / fireRate;
        Instantiate(bullet, bulletPosition.transform.position, bulletPosition.transform.rotation);
    }
}
