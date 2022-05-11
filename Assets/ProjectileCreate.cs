using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCreate : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    private GameObject bullet;
    private Bullet bulletSC;
    public GameObject Player;

    private void Awake()
    {
    }

    public void FireGun(float Damage)
    {
        Player = GameObject.Find("PlayerObject");
        Projectile = Resources.Load<GameObject>("Bullet");
        Debug.Log(this.name);
        Instantiate(Projectile,Player.transform.position,Player.transform.rotation);
        
        /*
        bulletSC = bullet.GetComponent<Bullet>();
        bulletSC.bulletDamage = Damage;
        */


    }
}
