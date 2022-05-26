using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelToggle : MonoBehaviour
{
    public GameObject WeaponWheel;
    public WeaponEquip WeaponEquip;
    public bool IsWheelActive;

    void Start()
    {
        WeaponWheel.SetActive(false);
        IsWheelActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WeaponEquip.CanShoot = false;
            WeaponWheel.SetActive(true);
            IsWheelActive = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            WeaponEquip.CanShoot = true;
            WeaponWheel.SetActive(false);
            IsWheelActive = false; 
        }

    }
}
