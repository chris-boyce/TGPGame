using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 5f;
    public Text NadeText;
    public int NumberOfNades = 5;
    public GameObject grenadePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && NumberOfNades > 0)
        {
            ThrowGrenade();
        }
    }

  public void ThrowGrenade()
    {
        NumberOfNades--;
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        NadeText.text = NumberOfNades.ToString() + " X";
    }
    public void AddNades()
    {
        NumberOfNades = NumberOfNades + 5;
        NadeText.text = NumberOfNades.ToString() + " X";
    }
}
