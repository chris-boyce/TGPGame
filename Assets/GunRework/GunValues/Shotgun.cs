using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShotgun : BaseGunClass, IGun
{
    public SuperShotgun() : base()
    {
        GunName = "Shotgun";
        GunCurrentAmmo = 4;
        GunMagSize = 4;
        GunMaxAmmo = 80;
        GunReserveAmmo = 80;
        GunFireRate = 1f;
        GunDamage = 10f;
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("pump_action_shotgun");
    }

    public override void Fire()
    {
        Debug.Log("Shotgun Firing");
    }

    public override void Reload()
    {

    }
}

