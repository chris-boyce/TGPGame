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
        FireRatePerSec = 1 / GunFireRate;
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("pump_action_shotgun");
        PC = GunObject.GetComponent<ProjectileCreate>();
    }

    public override void Fire()
    {
        if (Timer > FireRatePerSec && GunReserveAmmo > 0)
        {
            PC.SpreadGun(GunDamage);
            GunReserveAmmo--;
            Debug.Log(GunReserveAmmo);
            Timer = 0f;
        }
        else
        {
            Timer = Timer += Time.deltaTime;
        }
    }
    public override int returnAmmo()
    {
        return GunReserveAmmo;
    }
    public override int returnMaxAmmo()
    {
        return GunMaxAmmo;
    }


}

