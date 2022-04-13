using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneToGameplay : MonoBehaviour
{
    [SerializeField] PlayableDirector timelineIntro;
    [SerializeField] GameObject timeline;
    [SerializeField] GameObject playerCamera;
    [SerializeField] MonoBehaviour fpsControllerScript;
    bool cutsceneStarted = false;
    bool cutsceneSkipped = false;

    private void Update()
    {
        if (cutsceneStarted == false)
        {
            StartCoroutine(TimelineToGameplay());
            if (Input.GetKeyDown(KeyCode.Space) && cutsceneSkipped == false)
            {
                timelineIntro.time = timelineIntro.duration - 1;
                cutsceneSkipped = true;
            }
        }
    }
    IEnumerator TimelineToGameplay()
    {
        timelineIntro.enabled = true;
        timeline.SetActive(true);
        playerCamera.SetActive(false);   
        fpsControllerScript.enabled = false;
        yield return new WaitForSeconds((float)((float)timelineIntro.duration - timelineIntro.time));
        playerCamera.SetActive(true);
        fpsControllerScript.enabled = true;
        timelineIntro.enabled = false;
        timeline.SetActive(false);
        cutsceneStarted = true;
    }
}
