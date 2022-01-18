using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject bulletObject;
    public int bulletDamage;
    public float bulletSpeed = 10.0f;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }


    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(bulletObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);

            Debug.Log("Object was hit");
            Destroy(bulletObject);
        }
        if(other.CompareTag("Crate"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            Debug.Log("Object was hit");
            Destroy(bulletObject);
        }

    }

}
