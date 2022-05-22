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
        stopCutscene.Invoke();
        pauseManager.enabled = true;
        //SceneManager.LoadScene("MainMenu");
    }   
}
