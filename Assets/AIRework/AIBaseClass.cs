using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBaseClass : MonoBehaviour
{
    public enum EnemyState
    {
        ChasingPlayer,
        ChasingTurret,
        AttackingPlayer
    };
    public EnemyState m_EnemyState;
    public int EnemyValueScore;
    public NavMeshAgent m_NavMeshAgent;
    public GameObject Player;

    public virtual void Start()
    {
       // Player = GameObject.FindGameObjectWithTag("Player");
    }
    public virtual void EnemyStateChange() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }

    public virtual void ZombieAttack() { }

}
