using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16_Burst : BaseGunClass, IGun
{
    public float BurstTimer = 0;
    public bool CanBurst = true;
    public bool FirstBullet = false;
    public bool SecondBullet = false;
    public M16_Burst() : base()
    {
        GunName = "M16";
        GunCurrentAmmo = 35;
        GunMagSize = 35;
        GunMaxAmmo = 300;
        GunReserveAmmo = 300;
        GunFireRate = 1.5f;
        GunDamage = 22f;
        FireRatePerSec = 1 / GunFireRate;

    }
    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("m16_machine_gun");
        PC = GunObject.GetComponent<ProjectileCreate>();
    }

    public override void Fire()
    {
        if (Timer > FireRatePerSec)
        {
            CanBurst = true;
            FirstBullet = false;
            SecondBullet = false;
            BurstTimer = 0f;
            Timer = 0f;
        }
        else
        {
            Timer = Timer += Time.deltaTime;
        }
        if(CanBurst)
        {
            Burstfire();
        }
    }
    void Burstfire()
    {
        BurstTimer = BurstTimer += Time.deltaTime;
        //PC.FireGun(GunDamage);
        if(BurstTimer > 0.01f && FirstBullet == false)
        {
            PC.FireGun(GunDamage);
            FirstBullet = true;
        }
        if(BurstTimer > 0.1f && SecondBullet == false)
        {
            PC.FireGun(GunDamage);
            SecondBullet = true;
    
        }
        if(BurstTimer > 0.2f)
        {
            PC.FireGun(GunDamage);
            CanBurst = false;
        }
        


    }



}

