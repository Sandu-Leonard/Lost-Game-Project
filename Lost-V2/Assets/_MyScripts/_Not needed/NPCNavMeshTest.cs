using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavMeshTest : MonoBehaviour
{
    [SerializeField]
    private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    [SerializeField] Animator animator;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ChangeAgentAnimation();
        navMeshAgent.destination = playerPosition.position;
    }
    void ChangeAgentAnimation()
    {
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("walking", speed);
    }

}


