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
        FireRatePerSec = 1 / GunFireRate;
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("ak_machine_gun");
        GunSound = Resources.Load<AudioClip>("AKGunShot");
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

