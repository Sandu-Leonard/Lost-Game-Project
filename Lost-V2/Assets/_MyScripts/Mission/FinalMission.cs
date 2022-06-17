using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMission : MonoBehaviour
{
    [SerializeField] DoorManager mainDoor;
    [SerializeField] GameObject showDialogueText;
    private void OnEnable()
    {
        mainDoor.enabled = true;
        showDialogueText.SetActive(false);
    }
}
