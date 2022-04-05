using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToTeleporterTrigger : Interactable
{
    [SerializeField] GameObject skullPlaced;
    [SerializeField] GameObject skullKey;
    [SerializeField] Animator doorRightAnim;
    [SerializeField] Animator doorLeftAnim;



    bool isSkullPlaced = false;
    public int index = -1;

    public override string GetDescription()
    {
        if (isSkullPlaced == false && PlayerInventory.keys[index] == true)
            return "Press [E] to place the skull.";
        else
            return " ";
    }

    public override void Interact()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        if (isSkullPlaced == false && PlayerInventory.keys[index] == true)
        {
            skullPlaced.SetActive(true);
            doorRightAnim.SetTrigger("ironRopen");
            doorLeftAnim.SetTrigger("ironLopen");
            isSkullPlaced = true;
        }

    }
}
