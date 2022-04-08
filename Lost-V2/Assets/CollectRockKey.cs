using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRockKey : Interactable
{
    
    public override string GetDescription()
    {
        return "Press [E] to collect.";
    }

    public override void Interact()
    {
        gameObject.SetActive(false);     
    }

}
