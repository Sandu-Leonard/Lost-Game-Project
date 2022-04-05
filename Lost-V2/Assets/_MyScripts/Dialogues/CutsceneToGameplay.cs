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
        timelineIntro.enabled = false;
        fpsControllerScript.enabled = true;
        playerCamera.SetActive(true);
        cutsceneStarted = false;
    }
}
