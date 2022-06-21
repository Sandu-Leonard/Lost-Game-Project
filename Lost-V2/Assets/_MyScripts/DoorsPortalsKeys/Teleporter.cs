using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject teleportLocation;
    [SerializeField] private ParticleSystem teleportParticles;
    [SerializeField] private TMP_Text reticleText;

    private string playerTag = "Player";

    private bool readyToTeleport = false;
    private bool teleported = false;

    private void Update()
    {
        if (readyToTeleport && Input.GetKeyDown(KeyCode.E))
        {           
            StartCoroutine(Teleport());        
        }
    }
    IEnumerator Teleport()
    {
        if (teleported == false)
        {
            teleported = true;
            teleportParticles.Play();
            var mainParticleSettings = teleportParticles.main;
            yield return new WaitForSeconds(mainParticleSettings.duration);
            player.transform.position = teleportLocation.transform.position;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {      
        if (other.CompareTag(playerTag))
        {
            readyToTeleport = true;
            reticleText.text = "Press [E] to teleport.";
        }
    }
    private void OnTriggerExit(Collider other)
    {     
        readyToTeleport = false;
        reticleText.text = string.Empty;
        teleported = false;
    }

    
}
