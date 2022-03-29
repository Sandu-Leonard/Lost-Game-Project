using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenDoorToPart2 : MonoBehaviour
{
    public static int numberOfActiveSpheres = 0;

    [SerializeField] Animator doorAnimator;
    [SerializeField] GameObject timeline;
    [SerializeField] PlayableDirector timelineDirector;
    [SerializeField] GameObject playerCamera;
    [SerializeField] CharacterController player;

    private void Update()
    {
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        if (numberOfActiveSpheres == 4)
        {
            playerCamera.SetActive(false);
            timeline.SetActive(true);
            player.enabled = false;
            yield return new WaitForSeconds(0.5f);
            doorAnimator.SetTrigger("open");
            yield return new WaitForSeconds((float)timelineDirector.duration);
            timeline.SetActive(false);
            playerCamera.SetActive(true);
            player.enabled = true;
            numberOfActiveSpheres = 0;
        }
    }
}
