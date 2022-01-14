using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickupObject;
    public GameObject Player;



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
        if (other.CompareTag("Player"))
        {
            HealthUP();
        }
    }

    private void HealthUP()
    {
       // Player.GetComponentInChildren<Health>();
       // Player.transform.GetChild(1).GetComponent<Health>().currentHealth += 25;
        Destroy(pickupObject);
    }

}
