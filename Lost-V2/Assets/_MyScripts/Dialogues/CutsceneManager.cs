using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] int timeBeforeIsSkippable = 3;
    bool cutsceneStarted = false;
    bool cutsceneSkipped = false;

    [SerializeField]
    UnityEvent startCutscene;
    [SerializeField]
    UnityEvent stopCutscene;



    private void Update()
    {
        if (cutsceneStarted == false)
        {
            StartCoroutine(TimelineToGameplay());
            if (Input.GetKeyDown(KeyCode.Space) && cutsceneSkipped == false && playableDirector.time >= timeBeforeIsSkippable)
            {
                playableDirector.time = playableDirector.duration - 1;
                cutsceneSkipped = true;
            }
        }
    }
    IEnumerator TimelineToGameplay()
    {
        startCutscene.Invoke();
        yield return new WaitForSeconds(1.5f);
        yield return new WaitForSeconds((float)((float)playableDirector.duration - playableDirector.time));
        cutsceneStarted = true;
        stopCutscene.Invoke();
    }
}
