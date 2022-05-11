using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : BaseGunClass , IGun 
{
    private float FireRatePerSec;
    private float Timer;
    ProjectileCreate PC;

    public SMG() : base()
    {
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
        PC =  GunObject.GetComponent<ProjectileCreate>();
    }

    public override void Fire()
    {
        if (Timer > FireRatePerSec)
        {
            PC.FireGun(GunDamage);
            
            Timer = 0f;
        }
        else
        {
            Timer = Timer += Time.deltaTime;
        }

    }

    public override void Reload()
    {

    }
}
