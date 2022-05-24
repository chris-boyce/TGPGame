using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColour : MonoBehaviour
{
    // Start is called before the first frame update

    public Material hitMat;
    public Material originalMat;
    public Material lowhealthMat;

    [SerializeField]private GameObject Enemy;
    [SerializeField]private GameObject EnemyHealth;
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("EnemyColour");
        EnemyHealth = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet") && EnemyHealth.GetComponent<Health>().currentHealth > 40 )
        {
            StartCoroutine(HitTimer());
        }
        else if(other.CompareTag("Bullet") && EnemyHealth.GetComponent<Health>().currentHealth < 40)
        {
            StartCoroutine(DeathHitTimer());
        }
    }

    IEnumerator HitTimer()
    {
        Enemy.GetComponent<SkinnedMeshRenderer>().material = hitMat;
        yield return new WaitForSeconds(0.2f);
        Enemy.GetComponent<SkinnedMeshRenderer>().material = originalMat;
    }

    IEnumerator DeathHitTimer()
    {
        Enemy.GetComponent<SkinnedMeshRenderer>().material = lowhealthMat;
        yield return new WaitForSeconds(0.2f);
        Enemy.GetComponent<SkinnedMeshRenderer>().material = originalMat;
    }
}
