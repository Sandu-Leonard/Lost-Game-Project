using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : Interactable
{
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
        CollectMission.numberOfObjectsCollected++;   
    }
}
