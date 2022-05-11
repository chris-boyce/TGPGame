using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWP : BaseGunClass, IGun
{
    public AWP() : base()
    {
        GunName = "Sniper";
        GunCurrentAmmo = 5;
        GunMagSize = 5;
        GunMaxAmmo = 100;
        GunReserveAmmo = 100;
        GunFireRate = 0.5f;
        GunDamage = 100f;
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("sniper_rifle");
    }

    public override void Fire()
    {
        Debug.Log("Sniper Firing");
    }

    public override void Reload()
    {

    }
}
