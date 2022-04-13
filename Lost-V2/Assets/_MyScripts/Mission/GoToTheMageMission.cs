using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoToTheMageMission : MonoBehaviour
{
    [SerializeField] GameObject finalMission;

    private void Update()
    {
        if (FinalMageDialogue.talkedToTheMage == true)
        {
            finalMission.SetActive(true);
        }
    }

}
