using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
/// <summary>
/// Weapon Selector Script 
/// This code is used on the Player and unlocks weapons when picked up
/// If adding to Equipable objects you will need to add it to the ENUM PickupType
/// And then Add A Key to the Update Function
/// Afterwards head to WeaponEquip.cs and add functionality there
/// </summary>
public class WeaponSelector : MonoBehaviour
{
    [Header("Weapons Selected / Current Weapon")]
    public IPickupable testInterface;
    private PickupType UnlockWeapon;
    public PickupType WeaponWheelSelected;
    public PickupType CurrentWeapon;
    public IGun CurrentIGUN;
    public Dictionary<PickupType, bool> WeaponPool = new Dictionary<PickupType, bool>();

    private void Start()
    {
        //Adds Each Element of ENUM PickupTypes and sets the Value To false (Player Hasnt Unlocked Weapon)
       foreach(PickupType UnlockWeapon in Enum.GetValues(typeof(PickupType) ))
       {
            WeaponPool.Add(UnlockWeapon, false);
       }
       //Unlocks the Pistol and sets it as Start Weapon
        WeaponPool[PickupType.Pistol] = true;
        CurrentWeapon = PickupType.Pistol;
    }
    private void OnTriggerEnter(Collider other)
    {
        //If Player Collides with an object and it has the interface Ipickuapble
        IPickupable testInterface = other.gameObject.GetComponent<IPickupable>();
        if (testInterface != null)
        {
            //Sets the Unlock Weapon to changes the Players Weapon Pool to True (Player Unlocks the Item) and Destories Itself
            UnlockWeapon = testInterface.ReturnType();
            testInterface.OnDestory();
            WeaponPool[UnlockWeapon] = true;
        }

    }
    public void WeaponWheelInput(PickupType InputedWeapon)
    {
        Debug.Log(InputedWeapon);
        WeaponWheelSelected = InputedWeapon;
    }

    private void Update()
    {
        //Checks if Has Unlocked Weapon and Key is Pressed
        if (Input.GetKeyDown(KeyCode.Alpha1) && (WeaponPool[PickupType.Pistol] == true) || WeaponWheelSelected == PickupType.Pistol) 
        {
            CurrentWeapon = PickupType.Pistol;
            WeaponWheelSelected = PickupType.Empty;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && (WeaponPool[PickupType.Sniper] == true) || WeaponWheelSelected == PickupType.Sniper)
        {
            CurrentWeapon = PickupType.Sniper;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && (WeaponPool[PickupType.AutoPistol] == true) || WeaponWheelSelected == PickupType.AutoPistol)
        {
            CurrentWeapon = PickupType.AutoPistol;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && (WeaponPool[PickupType.P90] == true) || WeaponWheelSelected == PickupType.P90)
        {
            CurrentWeapon = PickupType.P90;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && (WeaponPool[PickupType.AK] == true) || WeaponWheelSelected == PickupType.AK)
        {
            CurrentWeapon = PickupType.AK;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && (WeaponPool[PickupType.M16] == true) || WeaponWheelSelected == PickupType.M16)
        {
            CurrentWeapon = PickupType.M16;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && (WeaponPool[PickupType.Shotgun] == true) || WeaponWheelSelected == PickupType.Shotgun)
        {
            CurrentWeapon = PickupType.Shotgun;
        }
    }

}
