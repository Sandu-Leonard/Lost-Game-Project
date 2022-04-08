using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BreakMission : MonoBehaviour
{
    public static int numberOfBrokenPieces = 3;
    [SerializeField] GameObject[] woodPieces;
    [SerializeField] Button breakMissionButton;

    [SerializeField]
    UnityEvent BreakMissionEvent;
    private void Update()
    {
        if(numberOfBrokenPieces == 0)
        {
            MissionProgress();
            BreakMissionEvent.Invoke();
        }
    }

    void MissionProgress()
    {
        MissionSelection.isAnyMissionInProgress = false;
        MissionSelection.numberOfCompletedMissions += 1;
        breakMissionButton.interactable = false;
    }
}
