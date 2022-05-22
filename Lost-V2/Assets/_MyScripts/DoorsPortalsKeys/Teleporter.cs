using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportLocation;
    [SerializeField] ParticleSystem teleportParticles;
    [SerializeField] TMP_Text reticleText;

    private string playerTag = "Player";

    bool readyToTeleport = false;
    bool teleportButtonPressed = false;

    private void Update()
    {
        if (readyToTeleport && Input.GetKeyDown(KeyCode.E))
        {           
            StartCoroutine(Teleport());        
        }
    }

    private void OnTriggerStay(Collider other)
    {      
        if (other.tag == playerTag)
        {
            readyToTeleport = true;
            reticleText.text = "Press [E] to teleport.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        reticleText.text = string.Empty;
        readyToTeleport = false;
        teleportButtonPressed = false;
    }

    IEnumerator Teleport()
    {
        if (!teleportButtonPressed)
        {
            teleportButtonPressed = true;
            teleportParticles.Play();
            yield return new WaitForSeconds(3);
            player.transform.position = teleportLocation.transform.position;          
        } 
    }
}
