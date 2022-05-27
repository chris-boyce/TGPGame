using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyNav enemyNav;
    private float enemyMeleeDamage = 10.0f;
    private RaycastHit hit;
    public GameObject rayPosition;
    public float hitRange = 5.0f;
    private bool canAttack;
    public AudioClip playerDamageSoound;

    private void Start()
    {
        enemyNav = GetComponent<EnemyNav>();
        canAttack = true;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(rayPosition.transform.position, rayPosition.transform.TransformDirection(Vector3.forward), out hit, hitRange))
        {
            Debug.DrawRay(rayPosition.transform.position, rayPosition.transform.TransformDirection(Vector3.forward) * hitRange, Color.yellow);

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Attakcing");
                if (canAttack == true)
                {
                    StartCoroutine(DamageTimer());
                }
            }
        }
    }

    IEnumerator DamageTimer()
    {
        canAttack = false;
        AudioSystem.PlaySoundEffect(playerDamageSoound);
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Health>().Damage(enemyMeleeDamage);
        enemyNav.enemyState = EnemyNav.EnemyState.AttackingPlayer;
        yield return new WaitForSeconds(1f);
        enemyNav.enemyState = EnemyNav.EnemyState.ChasingPlayer;
        canAttack = true;
    }
}
