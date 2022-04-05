using UnityEngine;

public class DoorSkullKey : Interactable
{
    [SerializeField] GameObject skullPlaced;
    [SerializeField] GameObject skullKey;
    [SerializeField] Animator doorAnim;

    string openAnimationName = "Open";

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
            doorAnim.SetTrigger(openAnimationName);
            isSkullPlaced = true;
        }

    }
}
