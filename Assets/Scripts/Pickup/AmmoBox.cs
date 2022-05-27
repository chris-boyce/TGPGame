using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public WeaponEquip WeaponEquip;

    private void Awake()
    {
        WeaponEquip = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponEquip>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pickup");
            AmmoUP();
        }
    }

    private void AmmoUP()
    {
        WeaponEquip.WeaponMaxAmmo();
        Destroy(this.gameObject);
    }
}
