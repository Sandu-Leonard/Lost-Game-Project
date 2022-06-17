using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FilipAI : MonoBehaviour
{
    [SerializeField]
    private Transform playerPosition;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private int walkingAnim;
    private float distanceToTeleport = 10f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        walkingAnim = Animator.StringToHash("walking");
    }

    private void Update()
    {
        ChangeAgentAnimation();
        navMeshAgent.destination = playerPosition.position;

        if (Vector3.Distance(navMeshAgent.nextPosition, playerPosition.position) >= distanceToTeleport)
        {
            navMeshAgent.Warp(playerPosition.position);
        }
    }
    void ChangeAgentAnimation()
    {
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat(walkingAnim, speed);
    }
}
