using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16_Burst : BaseGunClass, IGun
{
    public M16_Burst() : base()
    {
        GunName = "M16";
        GunCurrentAmmo = 35;
        GunMagSize = 35;
        GunMaxAmmo = 300;
        GunReserveAmmo = 300;
        GunFireRate = 2f;
        GunDamage = 22f;
        
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("m16_machine_gun");
    }

    public override void Fire()
    {
        Debug.Log("M16");
    }

    public override void Reload()
    {

    }
}

