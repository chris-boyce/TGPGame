using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    // Gun
    public GameObject bullet;
    public GameObject objGun;
    public Transform bulletPos;
    public float fireRate = 15f;
    public ParticleSystem muzzle;
    // Ammo
    public TextMeshProUGUI Text;
    public int ammoCount = 100;
    public bool canShoot;

    private float nextTimeToFire = 0f;
    void Start()
    {
        objGun.SetActive(true);
        canShoot = true;
    }

    private void FixedUpdate()
    {
  

    }

    void Update()
    {
        Text.text = "Ammo:" + ammoCount;

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canShoot == true)
        {
            Shoot();
        }

        if(ammoCount == 0)
        {
            canShoot = false;
        }
    }

    void Shoot()
    {
        ammoCount -= 1;
        muzzle.Play();
        nextTimeToFire = Time.time + 1f / fireRate;
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
    }

}
