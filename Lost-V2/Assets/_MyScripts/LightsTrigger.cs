using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsTrigger : MonoBehaviour
{

    public GameObject lightLeftRow;
    public GameObject lightRightRow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightLeftRow.SetActive(true);
            lightRightRow.SetActive(true);
        }
    }

}
