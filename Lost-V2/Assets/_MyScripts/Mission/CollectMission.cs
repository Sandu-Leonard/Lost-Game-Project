using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CollectMission : MonoBehaviour
{
    [SerializeField]
    public static int numberOfItemsToCollect = 5;
    [SerializeField] GameObject[] objectsToCollect;
    [SerializeField] Button collectMissionButton;

    [SerializeField]
    UnityEvent CollectMissionEvent;

    private void Update()
    {
        if (numberOfItemsToCollect == 0)
        {
            MissionProgress();
            CollectMissionEvent.Invoke();         
        }
    }

    void MissionProgress()
    {
        MissionSelection.isAnyMissionInProgress = false;
        MissionSelection.numberOfCompletedMissions += 1;
        collectMissionButton.interactable = false;
    }

}
