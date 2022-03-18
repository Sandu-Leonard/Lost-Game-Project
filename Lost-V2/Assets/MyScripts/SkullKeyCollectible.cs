using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullKeyCollectible : Interactable
{

    public int keyIndex = -1;

    public override string GetDescription()
    {
        return "Press [E] to pick up the skull!";
    }

    public override void Interact()
    {
        gameObject.SetActive(false);
        PlayerInventory.keys[GetComponent<SkullKeyCollectible>().keyIndex] = true;
    }

}



