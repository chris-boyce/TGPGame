using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseGunClass, IGun
{
    public Pistol() : base()
    {
        GunName = "Pistol";
        GunCurrentAmmo = 12;
        GunMagSize = 12;
        GunMaxAmmo = 144;
        GunReserveAmmo = 144;
        GunFireRate = 5f;
        GunDamage = 10f;
    }

    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("pistol");
    }

    public override void Fire()
    {
        Debug.Log("Pistol Firing");
    }

    public override void Reload()
    {

    }
}