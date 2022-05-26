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

    private Vector3 previousPosition;
    private float MoveSpeed;
    private bool IsAnim;

    [Header("Values For this Type Of Zombie")]
    public float EnemyOverideHealth = 50f;
    public float EnemyAttackSpeed = 1.333f;
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

        EnemyAnimState();

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
                if(Player != null)
                {
                    m_NavMeshAgent.SetDestination(Player.transform.position);
                }
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
        if (canAttack == true)
        {

            StartCoroutine(DamageTimer());
        }
   }
    IEnumerator DamageTimer()
    {
        canAttack = false;
        Anim.SetTrigger("AttackTrigger"); // Anim Does Attack
        Player.GetComponent<Health>().Damage(enemyMeleeDamage);
        m_EnemyState = EnemyState.AttackingPlayer;
        yield return new WaitForSeconds(EnemyAttackSpeed);
        m_EnemyState = EnemyState.ChasingPlayer;
        canAttack = true;
    }
    void EnemyAnimState()
    {
        //Calualates the speed the NavMeshAgent is moving
        Vector3 curMove = transform.position - previousPosition;
        MoveSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        if (MoveSpeed > 1f) //Checks if moving
        {
            Anim.SetFloat("SpeedOfAnimation", MoveSpeed / 3.14f); //Scales the movement to the speed they are moving (Pi is the closest to feel good in game. Idk why just worked it out)
            if (IsAnim == false)//Make it Only Run once / Less calls or conflicts
            {
                Anim.SetBool("IsWalking", true);
                IsAnim = true;
            }
        }
        else //If not moving then run the idle state
        {
            Anim.SetFloat("SpeedOfAnimation", 1);
            if (IsAnim == true)
            {
                Anim.SetBool("IsWalking", false);
                IsAnim = false;
            }
        }
    }


}
