using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private RespawnManager respawnManager;

    private void Start()
    {
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            respawnManager.lastCheckpointPosition = transform.position;
        }
    }
}
