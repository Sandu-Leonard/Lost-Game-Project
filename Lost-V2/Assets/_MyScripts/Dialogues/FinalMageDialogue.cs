using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class FinalMageDialogue : Interactable
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] PauseManager pauseManager;

    [SerializeField] UnityEvent startCutscene;
    [SerializeField] UnityEvent stopCutscene;


    bool cutsceneStarted = false;
    bool cutsceneSkipped = false;

    public static bool talkedToTheMage = false;

    IEnumerator StartCutscene()
    {
        cutsceneStarted = true;
        pauseManager.enabled = false;
        startCutscene.Invoke();
        yield return new WaitUntil(() => cutsceneSkipped);
        stopCutscene.Invoke();
        cutsceneStarted = false;
        cutsceneSkipped = false;
        talkedToTheMage = true;
        pauseManager.enabled = true;
    }

    private void Update()
    {
        if (cutsceneStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cutsceneSkipped == false)
            {
                playableDirector.time = playableDirector.duration - 1;
                cutsceneSkipped = true;
            }
        }
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
