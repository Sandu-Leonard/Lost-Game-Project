using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullColectible : Interactable
{
    public override string GetDescription()
    {
        return "Press [E] to pick up the skull!";
    }

    public override void Interact()
    {
        gameObject.SetActive(false);
    }

}
