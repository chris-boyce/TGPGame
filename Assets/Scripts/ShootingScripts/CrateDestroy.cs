using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrateDestroy : MonoBehaviour
{

    public GameObject pickUp;
    public GameObject pickUpPos;
    public GameObject pickUpCrate;
    public GameObject healthbar;

    // Start is called before the first frame update
   public void Start()
   {
        pickUp.SetActive(false);
        healthbar = GameObject.FindWithTag("PickupHealthbar");
   }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            pickUp.SetActive(true);
            Instantiate(pickUp, pickUpPos.transform.position, pickUpPos.transform.rotation);
            Destroy(pickUpCrate);
            Destroy(healthbar);
        }
    }
}
