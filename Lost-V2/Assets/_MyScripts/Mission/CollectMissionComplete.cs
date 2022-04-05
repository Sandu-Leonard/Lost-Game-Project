using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class CollectMissionComplete : Interactable
{
    [SerializeField] PlayableDirector dialogueMage;
    [SerializeField] GameObject timeline;
    [SerializeField] MonoBehaviour playerFpsController;
    [SerializeField] GameObject[] collectedObjects;
    [SerializeField] BoxCollider mageBoxCollider;
    [SerializeField] GameObject missionSelection;
    IEnumerator CompleteMission()
    {        
        timeline.SetActive(true);
        playerFpsController.enabled=false;
        mageBoxCollider.enabled = false;
        missionSelection.SetActive(true);
        yield return new WaitForSeconds((float)dialogueMage.duration);     
        timeline.SetActive(false);
        playerFpsController.enabled = true;
        foreach (var obj in collectedObjects)
        {
            obj.SetActive(true);
        }
    }
    public override string GetDescription()
    {
        return "Press [E] to give the ingredients.";
    }

    public override void Interact()
    {
        StartCoroutine(CompleteMission());
    }
}
