using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class DialogueFilipStart : Interactable
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] Animator animator;
    [SerializeField] FilipAI filipAI;

    [SerializeField] UnityEvent startCutscene;
    [SerializeField] UnityEvent stopCutscene;
    [SerializeField] UnityEvent selectMission;
    [SerializeField] UnityEvent stopSelectMission;

    private int standingAnimation;

    bool cutsceneStarted = false;
    bool cutsceneSkipped = false;

    public static bool selectMissionOn = false;

    private void Awake()
    {
        standingAnimation = Animator.StringToHash("standing");
    }

    IEnumerator StartCutscene()
    {
        cutsceneStarted = true;
        startCutscene.Invoke();      
        yield return new WaitUntil(() => cutsceneSkipped);      
        stopCutscene.Invoke();
        cutsceneStarted = false;
        cutsceneSkipped = false;
        StartCoroutine(StartMissionSelect());
    }
    IEnumerator StartMissionSelect()
    {
        selectMission.Invoke();       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;       
        yield return new WaitUntil(() => selectMissionOn);
        animator.SetTrigger(standingAnimation);
        filipAI.enabled = true;
        stopSelectMission.Invoke();
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
