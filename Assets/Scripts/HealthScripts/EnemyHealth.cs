using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    private float EnemiesHealth = 100f;
    public event System.Action OnDeath; // Wave Call depends on this script being run due to the Events System *Chris*
    public void TakeDamage(float damage)
    {
        EnemiesHealth -= damage;
        IsDead();
    }
    private void IsDead()
    {
        if(EnemiesHealth <= 0)
        {
            if(OnDeath != null)
            {
                OnDeath();
            }
            Destroy(gameObject);
        }
    }

}
