using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestroy : MonoBehaviour
{

    public Health health;
    public GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(thisObject.transform.GetComponent<Health>().currentHealth <= 0)
        {
            Debug.Log("pickup deployed");
        }
    }
}
