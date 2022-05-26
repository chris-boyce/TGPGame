using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AWP : BaseGunClass, IGun
{
    
    public AWP() : base()
    {
        Timer = 2f;
        GunName = "Sniper";
        GunCurrentAmmo = 5;
        GunMagSize = 5;
        GunMaxAmmo = 100;
        GunReserveAmmo = 100;
        GunFireRate = 0.5f;
        GunDamage = 100f;
        FireRatePerSec = 1 / GunFireRate;
        
    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("sniper_rifle");
        GunSound = Resources.Load<AudioClip>("SniperGunShot");
        PC = GunObject.GetComponent<ProjectileCreate>();
        AudioMixer _MasterMixer = Resources.Load("SoundEffects") as AudioMixer;

    }

    public override void Fire()
    {
        if (Timer > FireRatePerSec && GunReserveAmmo > 0)
        {
            Debug.Log("Shoot");
            GunReserveAmmo--;
            AudioSystem.PlaySoundEffect(GunSound);
            PC.FireGun(GunDamage);

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
