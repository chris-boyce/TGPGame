using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseZombie : AIBaseClass
{
    private Health HealthScript;
    private bool canAttack = true;
    public GameObject rayPosition;
    public Animator Anim;
    
    [Header("Values For this Type Of Zombie")]
    public float EnemyOverideHealth = 50f;
    public float EnemySpeed = 0.5f;
    public float hitRange = 5f;
    public float enemyMeleeDamage = 10.0f;


    public override void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HealthScript = GetComponent<Health>();
        HealthScript.health = EnemyOverideHealth;
        HealthScript.currentHealth = EnemyOverideHealth;
        m_EnemyState = EnemyState.ChasingPlayer;
        m_NavMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        m_NavMeshAgent.baseOffset = 0f;
        m_NavMeshAgent.speed = EnemySpeed;
        base.Start();
    }
    public override void Update()
    {
        EnemyStateChange();
    }
    public override void FixedUpdate()
    {
        HitRangeCheck();
    }
    public override void EnemyStateChange() //Choose What the Enemy is doing
    {
        switch (m_EnemyState)
        {
            case EnemyState.ChasingPlayer:
                Anim.SetBool("IsRunning", true);
                m_NavMeshAgent.SetDestination(Player.transform.position);
                break;
            case EnemyState.ChasingTurret:
                //TODO Add Turret Attack

                break;
            case EnemyState.AttackingPlayer:
                m_NavMeshAgent.SetDestination(transform.position);
                break;
        }
    }
    private void HitRangeCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayPosition.transform.position, rayPosition.transform.TransformDirection(Vector3.forward), out hit, hitRange))
        {
            Debug.DrawRay(rayPosition.transform.position, rayPosition.transform.TransformDirection(Vector3.forward) * hitRange, Color.yellow);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                ZombieAttack();
            }
        }
    }
   public override void ZombieAttack()
   {
        Anim.SetBool("IsAttacking", true);
        if (canAttack == true)
        {
            StartCoroutine(DamageTimer());
        }
   }
    IEnumerator DamageTimer()
    {
        Debug.Log("Attaking Prefab");
        canAttack = false;
        Player.GetComponent<Health>().Damage(enemyMeleeDamage);
        m_EnemyState = EnemyState.AttackingPlayer;
        yield return new WaitForSeconds(1f);
        m_EnemyState = EnemyState.ChasingPlayer;
        Anim.SetBool("IsAttacking", false);
        canAttack = true;
    }


}
