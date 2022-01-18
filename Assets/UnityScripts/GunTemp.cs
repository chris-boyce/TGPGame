using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTemp : MonoBehaviour
{

    public GameObject bullet;
    public GameObject objGun;
    public Transform bulletPos;
    public float fireRate = 15f;
    public ParticleSystem muzzle;
 

    private float nextTimeToFire = 0f;
    void Start()
    {
        objGun.SetActive(true);
    }

    private void FixedUpdate()
    {
  

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        muzzle.Play();
        nextTimeToFire = Time.time + 1f / fireRate;
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
    }

}
