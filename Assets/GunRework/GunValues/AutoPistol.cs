using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Auto : BaseGunClass, IGun
{
    public Pistol_Auto() : base()
    {
        GunName = "AutoPistol";
        GunCurrentAmmo = 15;
        GunMagSize = 15;
        GunMaxAmmo = 100;
        GunReserveAmmo = 100;
        GunFireRate = 12f;
        GunDamage = 8f;
    }

    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("machine_pistol_gun");
    }

    public override void Fire()
    {
        Debug.Log("Auto Pistol Firing");
    }

    public override void Reload()
    {

    }
}
