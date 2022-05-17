using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCreate : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    private Bullet bulletSC;
    private GameObject Bullet;
    public GameObject Player;
    Quaternion ShotgunRot;
    [SerializeField] private int ProjectileCount = 10;
    public bool CanShoot = true;
    public WeaponWheelToggle WeaponWheelToggle;
    public Transform GunMuzzle;
    public GameObject MuzzleFlash;

    //Yeet Update

    public void FireGun(float Damage)
    {
        WeaponWheelToggle = GameObject.FindGameObjectWithTag("WeaponWheel").GetComponent<WeaponWheelToggle>();
        
        if (!WeaponWheelToggle.IsWheelActive)
        {
            Player = GameObject.Find("PlayerObject");
            Projectile = Resources.Load<GameObject>("Bullet");
            Bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (Bullet != null)
            {
                Bullet.SetActive(true);
                Bullet.transform.position = Player.transform.position;
                Bullet.transform.rotation = Player.transform.rotation;
                bulletSC = Bullet.GetComponent<Bullet>();
                bulletSC.bulletDamage = Damage;
            }
        }
    }
    public void SpreadGun(float Damage)
    {
        WeaponWheelToggle = GameObject.FindGameObjectWithTag("WeaponWheel").GetComponent<WeaponWheelToggle>();
        if (!WeaponWheelToggle.IsWheelActive)
        {
            Player = GameObject.Find("PlayerObject");
            Projectile = Resources.Load<GameObject>("Bullet");

            for (int i = 0; i < ProjectileCount; i++)
            {
                
                ShotgunRot = Player.transform.rotation * Quaternion.Euler(0, Random.Range(-15, 15), 0);
                Bullet = Instantiate(Projectile, Player.transform.position, ShotgunRot);
                bulletSC = Bullet.GetComponent<Bullet>();
                bulletSC.bulletDamage = Damage;
            }
        }
    }
}
