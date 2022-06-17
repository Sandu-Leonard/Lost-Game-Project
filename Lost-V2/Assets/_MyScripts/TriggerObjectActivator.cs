using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectActivator : MonoBehaviour
{
    private string playerTag = "Player";
    [SerializeField]
    private GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            objectToActivate.SetActive(true);
            Destroy(gameObject, 2f);
        }

    }
}
