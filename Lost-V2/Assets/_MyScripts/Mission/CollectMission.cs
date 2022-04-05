using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMission : MonoBehaviour
{
    public static int numberOfObjectsCollected;
    [SerializeField] GameObject[] objectsToCollect;
    [SerializeField] GameObject completedMissionTrigger;
    [SerializeField] GameObject missionSelection;

    private void Update()
    {
        if (numberOfObjectsCollected == objectsToCollect.Length)
        {
            completedMissionTrigger.SetActive(true);
            missionSelection.SetActive(false);
            MissionSelection.isAnyMissonInProgress = false;
        }
    }
}
