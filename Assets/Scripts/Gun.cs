using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    private bool canShoot;

    void Start()
    {
        canShoot = true;
    }

    private void FixedUpdate()
    {
  

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && canShoot == true)
        {       
           StartCoroutine(FireBullet());
        }
    }

    IEnumerator FireBullet()
    {
        canShoot = false;
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

   

}
