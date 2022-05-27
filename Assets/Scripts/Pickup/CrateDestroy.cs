using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestroy : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject pickUpToInstantiate; 
    public GameObject pickUpToInstantiateLocation; 


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(pickUpToInstantiate, pickUpToInstantiateLocation.transform.position, pickUpToInstantiateLocation.transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
