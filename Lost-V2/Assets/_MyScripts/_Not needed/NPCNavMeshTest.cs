using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavMeshTest : MonoBehaviour
{
    [SerializeField]
    private Transform firstPosition;
    [SerializeField]
    private Transform secondPosition;
    //[SerializeField]
    //private Transform thirdPosition;
    [SerializeField]
    private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    private Transform navMeshAgentPosition;
    [SerializeField] Animator animator;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgentPosition = GetComponent<Transform>();
    }

    private void Update()
    {
        ChangeAgentAnimation();

        CheckAgentPositionToPlayer();
        if (BreakMission.numberOfBrokenPieces == 3)
        {
            navMeshAgent.destination = secondPosition.position;
        }
        else
        {
            navMeshAgent.destination = firstPosition.position;
        }
    }
    void ChangeAgentAnimation()
    {
        if (navMeshAgent.speed < 0.5)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            animator.SetTrigger("walk");
        }
    }

    void CheckAgentPositionToPlayer()
    {
        if (navMeshAgentPosition.position.x - playerPosition.position.x >= 3)
        {
            navMeshAgent.speed = 0;
        }
        else
            navMeshAgent.speed = 2;

    }
}


