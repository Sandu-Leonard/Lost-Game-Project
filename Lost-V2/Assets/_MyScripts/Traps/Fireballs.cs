using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject respawnPositionStart;
    [SerializeField] GameObject respawnPosition2;
    [SerializeField] GameObject key;
    [SerializeField] AudioSource shootSound;

    int currnetNumberOfParticles;

    ParticleSystem particleSys;
    private void Start()
    {
        particleSys = GetComponent<ParticleSystem>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
            if (key.activeInHierarchy)
            {
                player.transform.position = respawnPositionStart.transform.position;

            }
            else
            {
                player.transform.position = respawnPosition2.transform.position;
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
