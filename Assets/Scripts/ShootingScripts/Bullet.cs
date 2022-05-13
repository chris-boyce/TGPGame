using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject Player;
    public GameObject bulletObject;
    public GameObject tempObj;
    public float bulletDamage;
    public float bulletSpeed = 10.0f;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }
    private void Update()
    {

        StartCoroutine(DestroyBullet());
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward  * bulletSpeed;
    }

    IEnumerator DestroyBullet()
    {

        yield return new WaitForSeconds(0.8f);
        bulletObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Health>().Damage(bulletDamage); // Jon EDIT: Changed EnemyHealth to Health.

            Debug.Log("Object was hit");
            bulletObject.SetActive(false);
        }
        if(other.CompareTag("AmmoBox"))
        {
            other.gameObject.GetComponent<Health>().Damage(bulletDamage);
            Debug.Log("Object was hit");
            bulletObject.SetActive(false);
        }  
        if(other.CompareTag("HealthBox"))
        {
            other.gameObject.GetComponent<Health>().Damage(bulletDamage);
            Debug.Log("Object was hit");
            bulletObject.SetActive(false);
        }    
        if(other.CompareTag("Object"))
        {
            Debug.Log("Object was hit");
            bulletObject.SetActive(false);
        }

    }
}
