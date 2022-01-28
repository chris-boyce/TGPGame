using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestroy : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject pickUpToInstantiate; 
    public GameObject pickUpToInstantiateLocation; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(pickUpToInstantiate, pickUpToInstantiateLocation.transform.position, pickUpToInstantiateLocation.transform.rotation);
        }
    }

}
