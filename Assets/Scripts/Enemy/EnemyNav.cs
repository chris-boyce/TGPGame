using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private NavMeshAgent agent;
    public EnemyState enemyState;
    private GameObject player;
 
    public enum EnemyState
    {
        ChasingPlayer,
        ChasingTurret,
        AttackingPlayer
    };

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyState = EnemyState.ChasingPlayer;
        player = GameObject.FindGameObjectWithTag("Player"); // Jon EDIT: Fixes player tracking.
    }

    void Update()
    {
        switch(enemyState)
        {
            case EnemyState.ChasingPlayer:
                agent.SetDestination(player.transform.position);
                break;
            case EnemyState.ChasingTurret:
                //If hit by turret chase the turret and destroy it?
                break;
            case EnemyState.AttackingPlayer:
                agent.SetDestination(transform.position);
                StartCoroutine(DamageTimer());
                //If in range of player hit them ? Stop movement and swing?
                break;
        }
    }
    IEnumerator DamageTimer()
    {
        yield return new WaitForSeconds(0.5f);
        enemyState = EnemyState.ChasingPlayer;
    }
        
}



