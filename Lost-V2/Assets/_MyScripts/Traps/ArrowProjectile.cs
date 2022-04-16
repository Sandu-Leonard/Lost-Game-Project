using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{ 
    [SerializeField] Rigidbody rigidB;
    [SerializeField] float arrowSpeed = 300f;
    GameObject player;
    RespawnManager respawnManager;

    private void Start()
    {
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        rigidB.AddRelativeForce(new Vector3(0, 0, arrowSpeed));
        Destroy(gameObject, 5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("HIT!");
            Destroy(gameObject);
            player.GetComponent<Transform>().transform.position = respawnManager.lastCheckpointPosition;
        }
    }

}
