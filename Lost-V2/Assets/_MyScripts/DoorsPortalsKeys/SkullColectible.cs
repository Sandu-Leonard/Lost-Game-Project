using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullColectible : Interactable
{
    public int keyIndex = -1;
    [SerializeField] GameObject invisibleWallDoorTrigger;
    [SerializeField] GameObject arrowTraps;
    public override string GetDescription()
    {
        return "Press [E] to pick up the skull!";
    }

    public override void Interact()
    {
        gameObject.SetActive(false);
        invisibleWallDoorTrigger.SetActive(true);
        arrowTraps.SetActive(true);
        PlayerInventory.keys[GetComponent<SkullColectible>().keyIndex] = true;
    }

}
