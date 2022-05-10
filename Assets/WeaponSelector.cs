using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public IPickupable testInterface;
    private PickupType UnlockWeapon;
    public PickupType CurrentWeapon;
    private bool BoolValue;
    private bool ReturnValue;
    public Dictionary<PickupType, bool> WeaponPool = new Dictionary<PickupType, bool>();
    private void Start()
    {
       foreach(PickupType UnlockWeapon in Enum.GetValues(typeof(PickupType) ))
       {
            WeaponPool.Add(UnlockWeapon, false);
            Debug.Log(WeaponPool);
            Debug.Log(UnlockWeapon);
       }
        WeaponPool[PickupType.Pistol] = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Is Pick up");
        

        IPickupable testInterface = other.gameObject.GetComponent<IPickupable>();

        if (testInterface != null)
        {
            UnlockWeapon = testInterface.ReturnType();
            testInterface.OnDestory();
            WeaponPool[UnlockWeapon] = true;
            Debug.Log("True" + UnlockWeapon);
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && (WeaponPool[PickupType.Pistol] == true))
        {
            CurrentWeapon = PickupType.Pistol;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && (WeaponPool[PickupType.Sniper] == true))
        {
            CurrentWeapon = PickupType.Sniper;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && (WeaponPool[PickupType.AutoPistol] == true))
        {
            CurrentWeapon = PickupType.AutoPistol;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && (WeaponPool[PickupType.P90] == true))
        {
            CurrentWeapon = PickupType.P90;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && (WeaponPool[PickupType.AK] == true))
        {
            CurrentWeapon = PickupType.AK;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && (WeaponPool[PickupType.M16] == true))
        {
            CurrentWeapon = PickupType.M16;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && (WeaponPool[PickupType.Shotgun] == true))
        {
            CurrentWeapon = PickupType.Shotgun;
        }
    }

}
