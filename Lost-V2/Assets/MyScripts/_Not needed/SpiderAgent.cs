using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderAgent : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent spider;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform navMeshAgentPosition;

    private static readonly int AttackHash = Animator.StringToHash("Attack");




    void Update()
    {
        spider.SetDestination(player.position);
        Attack();
    }


    void Attack()
    {
        if (spider.remainingDistance <=2)
        {
            animator.SetTrigger(AttackHash);
        }
    }
}
