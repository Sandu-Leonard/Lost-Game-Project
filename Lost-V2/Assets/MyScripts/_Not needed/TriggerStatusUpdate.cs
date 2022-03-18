using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStatusUpdate : MonoBehaviour
{
    
    [SerializeField]
    GameObject objectiveStatus;

    [SerializeField]
    GameObject currentObjective;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectiveStatus.SetActive(true);
            currentObjective.SetActive(false);
        }
    }
}
