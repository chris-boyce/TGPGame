using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject Player;
 [SerializeField] private GameObject Enemy;
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
            Debug.Log("Object was hit");
            bulletObject.SetActive(false);
        }  
        if(other.CompareTag("HealthBox"))
        {
            Debug.Log("Object was hit");
            bulletObject.SetActive(false);
        }    
        if(other.CompareTag("Object"))
        {
            Debug.Log("Object was hit");
            bulletObject.SetActive(false);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3f);
        bulletObject.SetActive(false);
    }
}

