using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMission : MonoBehaviour
{
    [SerializeField] DoorManager mainDoor;
    private void OnEnable()
    {
        mainDoor.enabled = true;
    }
}
