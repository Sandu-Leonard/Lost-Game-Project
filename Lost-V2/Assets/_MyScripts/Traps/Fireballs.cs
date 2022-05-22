using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioSource shootSound;
    private RespawnManager respawnManager;

    private string playerTag = "Player";

    int currnetNumberOfParticles;

    ParticleSystem particleSys;
    private void Start()
    {
        particleSys = GetComponent<ParticleSystem>();
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(playerTag))
        {
            player.transform.position = respawnManager.lastCheckpointPosition;
        }
            
    }

    private void Update()
    {
        if (particleSys.particleCount > currnetNumberOfParticles)
        {
            shootSound.Play();
        }

        currnetNumberOfParticles = particleSys.particleCount;
    }
}
