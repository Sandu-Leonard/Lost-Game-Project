using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class MissionComplete : Interactable
{
    [SerializeField] PlayableDirector dialogueMage;
    [SerializeField] GameObject timeline;
    [SerializeField] MonoBehaviour playerFpsController;
    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] BoxCollider mageBoxCollider;
    [SerializeField] GameObject missionSelection;

    [SerializeField] GameObject completeMissionStatus;
    [SerializeField] GameObject finishedMissionsDialogue;

    IEnumerator CompleteMission()
    {
        timeline.SetActive(true);
        playerFpsController.enabled = false;
        mageBoxCollider.enabled = false;
        completeMissionStatus.SetActive(false);
        yield return new WaitForSeconds((float)dialogueMage.duration);
        timeline.SetActive(false);
        playerFpsController.enabled = true;
        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
        if (MissionSelection.numberOfCompletedMissions == 2)
            finishedMissionsDialogue.SetActive(true);
        else
            missionSelection.SetActive(true);
    }
    public override string GetDescription()
    {
        return "Press [E] to talk.";
    }

    public override void Interact()
    {

        StartCoroutine(CompleteMission());
    }
}
