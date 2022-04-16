using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    RespawnManager respawnManager;


    private void Start()
    {
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        player.transform.position = respawnManager.lastCheckpointPosition;
    }
}
