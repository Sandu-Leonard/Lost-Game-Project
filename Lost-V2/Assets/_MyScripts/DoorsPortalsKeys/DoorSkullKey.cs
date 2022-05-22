using UnityEngine;

public class DoorSkullKey : Interactable
{
    [SerializeField] GameObject skullPlaced;
    [SerializeField] GameObject skullKey;
    [SerializeField] Animator doorAnim;

    private int openAnimationName;

    bool isSkullPlaced = false;
    public int index = -1;

    private void Awake()
    {
        openAnimationName = Animator.StringToHash("Open");
    }

    public override string GetDescription()
    {
        if (isSkullPlaced == false && PlayerInventory.keys[index] == true)
            return "Press [E] to place the skull.";
        else if (isSkullPlaced == false && PlayerInventory.keys[index] == false)
            return "I need something to activate this with.";
        else return "";
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
