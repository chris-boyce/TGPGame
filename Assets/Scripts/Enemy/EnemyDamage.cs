using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyNav enemyNav;
    private float enemyMeleeDamage = 10f;
    private RaycastHit hit;

    private void Start()
    {
        enemyNav = GetComponent<EnemyNav>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Damage(enemyMeleeDamage);
            enemyNav.enemyState = EnemyNav.EnemyState.AttackingPlayer;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
          
        }
    }
}
