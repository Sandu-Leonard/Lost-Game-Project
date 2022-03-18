using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavMeshTest : MonoBehaviour
{
    [SerializeField]
    private Transform positionToMoveTo;
    [SerializeField]
    //private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    private Transform navMeshAgentPosition;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgentPosition = GetComponent<Transform>();
    }

    private void Update()
    {

        //if (navMeshAgentPosition.position.x - playerPosition.position.x >= 5)
        //{
        //    navMeshAgent.speed = 0;
        //}
        //else
        //{
        //    navMeshAgent.speed = 2;
        //    navMeshAgent.destination = positionToMoveTo.position;
        //}

        navMeshAgent.destination = positionToMoveTo.position;

    }

}
