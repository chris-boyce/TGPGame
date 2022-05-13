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

    //Yeet Update

    public void FireGun(float Damage)
    {
        Player = GameObject.Find("PlayerObject");
        Projectile = Resources.Load<GameObject>("Bullet");
        Debug.Log(this.name);
        Bullet = Instantiate(Projectile,Player.transform.position,Player.transform.rotation);
        bulletSC = Bullet.GetComponent<Bullet>();
        bulletSC.bulletDamage = Damage;


    }
    public void SpreadGun(float Damage)
    {
        Debug.Log("Shotgun Shot");
        Player = GameObject.Find("PlayerObject");
        Projectile = Resources.Load<GameObject>("Bullet");

        for (int i = 0; i < 5; i++)
        {
            ShotgunRot = Player.transform.rotation * Quaternion.Euler(0, Random.Range(-15, 15), 0);
            Bullet = Instantiate(Projectile, Player.transform.position, ShotgunRot);
            bulletSC = Bullet.GetComponent<Bullet>();
            bulletSC.bulletDamage = Damage;
        }

            
    }
}
