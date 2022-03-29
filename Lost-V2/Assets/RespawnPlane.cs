using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlane : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject respawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = respawnPosition.transform.position;
        }
    }
}
