using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyDrop : MonoBehaviour
{
    public GameObject SupplyDropUI;
    private void Start()
    {
        this.gameObject.SetActive(false);
        SupplyDropUI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SupplyDropUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SupplyDropUI.SetActive(false);
        }
    }
    public void CloseMenu()
    {
        this.gameObject.SetActive(false);
        SupplyDropUI.SetActive(false);
    }


}
