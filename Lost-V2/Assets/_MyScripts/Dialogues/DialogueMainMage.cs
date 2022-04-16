using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueMainMage : Interactable
{
    [Header("Timeline")]
    [SerializeField] PlayableDirector dialogueMage;
    [SerializeField] GameObject timeline;
    [Header("Player Movement Script")]
    [SerializeField] MonoBehaviour fpsController;
    [Space(10)]
    [SerializeField] GameObject dialogueScript;
    [SerializeField] GameObject missionSelectionScript;
    [SerializeField] GameObject keyToFilipsCell;
    [SerializeField] PauseManager pauseManager;
    bool cutsceneStarted = false;
    bool cutsceneSkipped = false;

    IEnumerator StartCutscene()
    {        
        cutsceneStarted = true;
        timeline.SetActive(true);
        fpsController.enabled = false;
        pauseManager.enabled = false;
        yield return new WaitUntil(() => cutsceneSkipped);
        timeline.SetActive(false);
        fpsController.enabled = true;
        cutsceneStarted = false;
        cutsceneSkipped = true;
        if (MissionSelection.numberOfCompletedMissions < 2)
        {
            missionSelectionScript.SetActive(true);
        }
        else
        {
            keyToFilipsCell.SetActive(true);
        }
        pauseManager.enabled = true;
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

    private void Update()
    {
        if (cutsceneStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cutsceneSkipped == false)
            {
                dialogueMage.time = dialogueMage.duration - 1;
                cutsceneSkipped = true;
            }
        }
    }
}
