using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int selectedWeapon;
    private bool canSwitchWeapon;
    public Gun squareGun;
    public Sniper capGun;

    // Start is called before the first frame update
    void Start()
    {
        canSwitchWeapon = true;
        selectedWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int prevSelectedWeapon = selectedWeapon;

        // Input for each selected weapon
        if (Input.GetKeyDown(KeyCode.Alpha1) && canSwitchWeapon == true)
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canSwitchWeapon == true)
        {
            selectedWeapon = 1;
        }

        // If statements to turn on the weapon depending which key has been pressed
        if (selectedWeapon == 0)
        {
            capGun.objSniper.SetActive(false);
        }
        else
        {
            capGun.objSniper.SetActive(true);
        }

        if (selectedWeapon == 1)
        {
            squareGun.objGun.SetActive(false);
        }
        else
        {
            squareGun.objGun.SetActive(true);
        }


        // Cycles through the weapons activating them or deactivating them
        if (prevSelectedWeapon != selectedWeapon && canSwitchWeapon == true)
        {
            SelectWeapon();
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
