using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSwitcher : MonoBehaviour
{
    private int selectedWeapon;
    public bool canSwitchWeaponToSniper;
    public bool canSwitchWeaponToMachinePistol;

    public Gun pistol;
    public Sniper sniper;
    public MachinePistol machinePistol;
    public GameObject sniperObject;
    public GameObject machinePistolObject;
    // Start is called before the first frame update
    void Start()
    {
        canSwitchWeaponToSniper = false;
        canSwitchWeaponToMachinePistol = false;
        selectedWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int prevSelectedWeapon = selectedWeapon;

        // Input for each selected weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canSwitchWeaponToSniper == true)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && canSwitchWeaponToMachinePistol == true)
        {
            selectedWeapon = 2;
        }


        // If statements to turn on the weapon depending which key has been pressed
        //Sniper
        if (selectedWeapon == 0)      
        {

            pistol.objPistol.SetActive(true);
        }
        else
        {

            pistol.objPistol.SetActive(false);
        }
        //Pistol
        if (selectedWeapon == 1)
        {
            sniper.objSniper.SetActive(true);

        }
        else
        {
            sniper.objSniper.SetActive(false);

        }
        // Machine Pistol
        if (selectedWeapon == 2)
        {
            machinePistol.objMachinePistol.SetActive(true);
        }
        else
        {
            machinePistol.objMachinePistol.SetActive(false);
        }





        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Cycles through the weapons activating them or deactivating them
        if (prevSelectedWeapon != selectedWeapon && canSwitchWeaponToSniper == true && canSwitchWeaponToMachinePistol == true)
        {
           SelectWeapon();
        }

    }

    // Detect Weapon On Floor 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SniperObject"))
        {
            canSwitchWeaponToSniper = true;
            Destroy(sniperObject);
        }
        if (other.CompareTag("MachinePistol"))
        {
            canSwitchWeaponToMachinePistol = true;
            Destroy(machinePistolObject);
        }

    }



    void SelectWeapon()
    {
        int i = 0;
        // Turns on the object that is selected
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }


    }

}
