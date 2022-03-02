using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneToGameplay : MonoBehaviour
{
    [SerializeField] GameObject timeline;
    [SerializeField] GameObject playerCamera;
    [SerializeField] float cutsceneDuration = 55;
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
        playerCamera.SetActive(false);
        timeline.SetActive(true);  
        yield return new WaitForSeconds(cutsceneDuration);
        timeline.SetActive(false);
        playerCamera.SetActive(true);
        cutsceneStarted = false;
        
    }
}
