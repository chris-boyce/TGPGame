using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SMG : BaseGunClass , IGun 
{

    public SMG() : base()
    {
        Timer = 2f;
        GunName = "SMG";
        GunCurrentAmmo = 50;
        GunMagSize = 50;
        GunMaxAmmo = 300;
        GunReserveAmmo = 300;
        GunFireRate = 8f;
        GunDamage = 20f;
        FireRatePerSec = 1 / GunFireRate;
        
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("submachine_gun");
        GunSound = Resources.Load<AudioClip>("P90GunShot");
        PC =  GunObject.GetComponent<ProjectileCreate>();
        AudioMixer _MasterMixer = Resources.Load("SoundEffects") as AudioMixer;

    }

    public override void Fire()
    {
        if (Timer > FireRatePerSec)
        {
            PC.FireGun(GunDamage);
            AudioSystem.PlaySoundEffect(GunSound);
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
