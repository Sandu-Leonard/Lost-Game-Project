using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneToGameplay : MonoBehaviour
{
    [SerializeField] PlayableDirector timelineIntro;
    [SerializeField] GameObject playerCamera;
    [SerializeField] MonoBehaviour fpsControllerScript;
    bool cutsceneStarted = true;

    private void Update()
    {
        if (cutsceneStarted)
        {
            StartCoroutine(TimelineToGameplay());
        }
    }

    IEnumerator TimelineToGameplay()
    {
        timelineIntro.enabled = true;
        playerCamera.SetActive(false);   
        fpsControllerScript.enabled = false;
        yield return new WaitForSeconds((float)timelineIntro.duration);
        playerCamera.SetActive(true);
        fpsControllerScript.enabled = true;
        timelineIntro.enabled = false;               
        cutsceneStarted = false;
    }
}
