using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunAmmoHud : MonoBehaviour
{
    WeaponEquip weaponEquip;
    private int CurrentAmmo;
    private int MaxAmmo;
    private TextMeshProUGUI AmmoText;
    private void Start()
    {
        weaponEquip = GetComponent<WeaponEquip>();
        AmmoText = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        CurrentAmmo = weaponEquip.CurrentIGUN.returnAmmo();
        MaxAmmo = weaponEquip.CurrentIGUN.returnMaxAmmo();

        AmmoText.text = "AMMO : " + CurrentAmmo.ToString() +"/" + MaxAmmo.ToString();

    }

}
