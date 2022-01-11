using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject bullet;
    float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(10.0f, 0.0f,0.0f) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBullet());
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(bullet);
    }

}
