using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CrateDestroy : MonoBehaviour
{

    public GameObject pickUpCrate;
    public GameObject pickup;
    public GameObject pickUpPos;


    // Start is called before the first frame update
    void Start()
    {
        pickup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            pickup.SetActive(true);
            Instantiate(pickup.gameObject, pickUpPos.transform.position, pickUpPos.transform.rotation);
            Destroy(pickUpCrate);
        }
    }
}
