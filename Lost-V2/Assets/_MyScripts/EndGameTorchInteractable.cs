using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndGameTorchInteractable : Interactable
{
    [SerializeField] PlayableDirector timeline;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] UnityEvent startCutscene;
    [SerializeField] UnityEvent stopCutscene;
    [SerializeField] GameObject credits;

    bool canSkip = false;
    bool cutsceneFinished = false;


    bool interacted = false;
    
    
    public override string GetDescription()
    {
        if (!interacted)
            return "Press [E].";
        return "";
    }

    public override void Interact()
    {       
        interacted = true;
        StartCoroutine(StartEndCutscene());
    }

    IEnumerator StartEndCutscene()
    {
        pauseManager.enabled = false;
        startCutscene.Invoke();
        yield return new WaitForSeconds((float)timeline.duration);
        cutsceneFinished = true;
        stopCutscene.Invoke();
        //pauseManager.enabled = true;
        yield return new WaitUntil(() => canSkip == true);
        pauseManager.LoadingScreen();
    }

    private void Update()
    {
        if (interacted == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cutsceneFinished == true)
            {
                credits.SetActive(false);

                pauseManager.enabled = true;
                canSkip = true;
            }
        }
    }
}
