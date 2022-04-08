using TMPro;
using UnityEngine;
public class CollectObject : Interactable
{
    [SerializeField] TMP_Text missionStatus;
    public override string GetDescription()
    {
        return "Press [E] to collect.";
    }

    public override void Interact()
    {
        CollectTheObject();
    }

    void CollectTheObject()
    {
        gameObject.SetActive(false);
        CollectMission.numberOfItemsToCollect--;
        missionStatus.text = $"{CollectMission.numberOfItemsToCollect} left";
    }

}
