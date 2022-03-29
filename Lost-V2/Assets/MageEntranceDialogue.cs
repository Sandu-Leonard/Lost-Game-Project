using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MageEntranceDialogue : Interactable
{
    [SerializeField] PlayableDirector dialogueMage;
    [SerializeField] GameObject timeline;
    [SerializeField] CharacterController fpsController;
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
