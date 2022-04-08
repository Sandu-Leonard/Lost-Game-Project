using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueMainMage : Interactable
{
    [SerializeField] PlayableDirector dialogueMage;
    [SerializeField] GameObject timeline;
    [SerializeField] MonoBehaviour fpsController;
    [SerializeField] GameObject dialogueScript;
    [SerializeField] GameObject missionSelectionScript;
    bool cutsceneStarted = false;

    IEnumerator StartCutscene()
    {
        cutsceneStarted = true;
        timeline.SetActive(true);
        fpsController.enabled = false;
        yield return new WaitForSeconds((float)dialogueMage.duration);
        timeline.SetActive(false);
        fpsController.enabled = true;
        cutsceneStarted = false;
        if (MissionSelection.numberOfCompletedMissions < 2)
        {
            missionSelectionScript.SetActive(true);
        }
        dialogueScript.SetActive(false);
    }

    public override string GetDescription()
    {
        if (cutsceneStarted == false)
            return "Press [E] to talk.";
        return "";
    }

    public override void Interact()
    {
        if (!cutsceneStarted)
        {
            StartCoroutine(StartCutscene());
        }
    }
}
