using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
        GunDamage = 25f;
        FireRatePerSec = 1 / GunFireRate;
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("pump_action_shotgun");
        GunSound = Resources.Load<AudioClip>("ShotgunGunShot");
        PC = GunObject.GetComponent<ProjectileCreate>();
        AudioMixer _MasterMixer = Resources.Load("SoundEffects") as AudioMixer;

    }

    public override void Fire()
    {
        if (Timer > FireRatePerSec && GunReserveAmmo > 0)
        {
            AudioSystem.PlaySoundEffect(GunSound);
            PC.SpreadGun(GunDamage);
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

