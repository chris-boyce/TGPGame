using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunClass : IGun
{
    public string GunName = "BaseGun";
    public int GunCurrentAmmo = 0;
    public int GunMagSize = 0;
    public int GunMaxAmmo = 0;
    public int GunReserveAmmo = 0;
    public float GunFireRate = 0;
    public float GunDamage = 0;
    public GameObject GunObject;
    public ProjectileCreate PC;
    public float Timer = 2f;
    public float FireRatePerSec;

    public virtual void GetGun() { }

    virtual public void Fire() { }

    virtual public int returnAmmo()
    {
        return GunCurrentAmmo;
    }

    virtual public int returnMaxAmmo()
    {
        return GunMaxAmmo;
    }
}
