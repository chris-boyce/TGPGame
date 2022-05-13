using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunAmmoHud : MonoBehaviour
{
    WeaponEquip weaponEquip;
    private int CurrentAmmo;
    private int MaxAmmo;
    public TextMeshProUGUI AmmoText;
    private void Start()
    {
        weaponEquip = GetComponent<WeaponEquip>();
    }
    private void Update()
    {
        CurrentAmmo = weaponEquip.CurrentIGUN.returnAmmo();
        MaxAmmo = weaponEquip.CurrentIGUN.returnMaxAmmo();

        AmmoText.text = "AMMO : " + CurrentAmmo.ToString() +"/" + MaxAmmo.ToString();

    }

}
