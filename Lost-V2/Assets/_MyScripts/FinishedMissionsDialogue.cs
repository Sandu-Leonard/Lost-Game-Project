using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedMissionsDialogue : Interactable
{
    public override string GetDescription()
    {
        return "Press [E] to talk.";
    }

    public override void Interact()
    {
       
    }

    //IEnumerator StartDialogue()
    //{
    //    timeline.SetActive(true);
    //    playerFpsController.enabled = false;
    //    mageBoxCollider.enabled = false;
    //    completeMissionStatus.SetActive(false);
    //    yield return new WaitForSeconds((float)dialogueMage.duration);
    //    timeline.SetActive(false);
    //    playerFpsController.enabled = true;
    //    foreach (var obj in objectsToActivate)
    //    {
    //        obj.SetActive(true);
    //    }
    //    missionSelection.SetActive(true);
    //}
}
