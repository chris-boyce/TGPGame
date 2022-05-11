using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : BaseGunClass, IGun
{
    public AK47() : base()
    {
        GunName = "AK47";
        GunCurrentAmmo = 30;
        GunMagSize = 30;
        GunMaxAmmo = 300;
        GunReserveAmmo = 300;
        GunFireRate = 5f;
        GunDamage = 25f;
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("ak_machine_gun");
    }

    public override void Fire()
    {
        Debug.Log("AK47 Firing");
    }

    public override void Reload()
    {

    }
}

