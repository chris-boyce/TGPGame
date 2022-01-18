using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float EnemiesHealth = 100f;
    public event System.Action OnDeath;
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
