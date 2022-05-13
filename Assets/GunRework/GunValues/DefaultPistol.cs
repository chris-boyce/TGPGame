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
        PC = GunObject.GetComponent<ProjectileCreate>();
    }

    public override void Fire()
    {

            PC.FireGun(GunDamage);
        
    }

}