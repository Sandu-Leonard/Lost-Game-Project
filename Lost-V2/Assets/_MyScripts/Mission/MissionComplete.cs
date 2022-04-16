using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class MissionComplete : Interactable
{
    [Header("Timeline")]
    [SerializeField] PlayableDirector dialogueMage;
    [SerializeField] GameObject timeline;
    [Header("Player Movement Script")]
    [SerializeField] MonoBehaviour playerFpsController;
    [Space(10)]
    [SerializeField] GameObject[] objectsToActivate;
    [Header("Mage Collider")]
    [SerializeField] BoxCollider mageBoxCollider;
    [Header("Mission Selection Script")]
    [SerializeField] GameObject missionSelection;
    [Header("Mission Status")]
    [SerializeField] GameObject completeMissionStatus;
    [SerializeField] GameObject finishedMissionsDialogue;
    [Space(10)]
    [SerializeField] PauseManager pauseManager;

    bool cutsceneSkipped = false;
    IEnumerator CompleteMission()
    {
        pauseManager.enabled = false;
        timeline.SetActive(true);
        playerFpsController.enabled = false;
        mageBoxCollider.enabled = false;
        completeMissionStatus.SetActive(false);
        yield return new WaitForSeconds((float)((float)dialogueMage.duration - dialogueMage.time));
        timeline.SetActive(false);
        playerFpsController.enabled = true;
        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
        if (MissionSelection.numberOfCompletedMissions == 2)
            finishedMissionsDialogue.SetActive(true);
        else
        {
            missionSelection.SetActive(true);
        }
        pauseManager.enabled = true;
        
    }
    public override string GetDescription()
    {
        return "Press [E] to talk.";
    }

    public override void Interact()
    {
        StartCoroutine(CompleteMission());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cutsceneSkipped == false)
        {
            dialogueMage.time = dialogueMage.duration - 1;
            cutsceneSkipped = true;
        }
    }
}
