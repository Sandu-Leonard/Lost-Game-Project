using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CutsceneToGameplay : MonoBehaviour
{
    [SerializeField] GameObject timeline;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerStartPosition;
    [SerializeField] float cutsceneDuration = 55;
    public MonoBehaviour script;
    CharacterController characterController;
    bool cutsceneStarted = true;

    private void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, playerStartPosition.transform.eulerAngles.y, player.transform.eulerAngles.z);
        player.transform.position = playerStartPosition.transform.position;  
    }


    private void Update()
    {
        if (cutsceneStarted)
        {
            StartCoroutine(TimelineToGameplay());
        }
    }

    IEnumerator TimelineToGameplay()
    {
        characterController.enabled = false;
        timeline.SetActive(true);
        script.enabled = false;
        yield return new WaitForSeconds(cutsceneDuration);
        timeline.SetActive(false);
        characterController.enabled = true;
        script.enabled = true;
        cutsceneStarted = false;
        
    }
}
