using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private RespawnManager respawnManager;

    private void Awake()
    {
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
        transform.position = respawnManager.lastCheckpointPosition;
    }

}
