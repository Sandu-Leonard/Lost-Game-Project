using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private RespawnManager respawnManager;

    private void Awake()
    {
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
        transform.position = respawnManager.lastCheckpointPosition;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        transform.position = respawnManager.lastCheckpointPosition;
    //    }
    //}
}
