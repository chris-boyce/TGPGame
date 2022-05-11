using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunClass : IGun
{
    public GameObject GunObject;
    public string GunName = "BaseGun";
    public int GunCurrentAmmo = 0;
    public int GunMagSize = 0;
    public int GunMaxAmmo = 0;
    public int GunReserveAmmo = 0;
    public float GunFireRate = 0;
    public float GunDamage = 0;
    public GameObject Projectile;

    public void MakeBullet(float BulletDamage)
    {
        
    }
    public virtual void GetGun()
    {

    }

    virtual public void Fire()
    {
        
    }

    virtual public void Reload()
    {
        
    }
}
