using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestroy : MonoBehaviour
{

    public GameObject pickUp;
    public GameObject pickUpPos;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(pickUp, pickUpPos.transform.position, pickUpPos.transform.rotation);
            Destroy(pickUp);
        }
    }
}
