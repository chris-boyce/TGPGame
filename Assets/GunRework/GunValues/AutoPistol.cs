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
        FireRatePerSec = 1 / GunFireRate;
    }

    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("machine_pistol_gun");
        GunSound = Resources.Load<AudioClip>("AutoPistolGunShot");
        PC = GunObject.GetComponent<ProjectileCreate>();
    }

    public override void Fire()
    {
        if (Timer > FireRatePerSec)
        {
            AudioSoundManager.PlaySoundEffect(GunSound);
            PC.FireGun(GunDamage);
            GunReserveAmmo--;
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
