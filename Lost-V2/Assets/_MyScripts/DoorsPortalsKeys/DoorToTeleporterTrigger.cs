using UnityEngine;

public class DoorToTeleporterTrigger : Interactable
{
    [SerializeField] GameObject skullPlaced;
    [SerializeField] GameObject skullKey;
    [SerializeField] Animator doorRightAnim;
    [SerializeField] Animator doorLeftAnim;

    private int openRightDoorAnimation;
    private int openLeftDoorAnimation;

    private void Awake()
    {
        openRightDoorAnimation = Animator.StringToHash("ironRopen");
        openLeftDoorAnimation = Animator.StringToHash("ironLopen");

    }

    bool isSkullPlaced = false;
    public int index = -1;

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
            doorRightAnim.SetTrigger(openRightDoorAnimation);
            doorLeftAnim.SetTrigger(openLeftDoorAnimation);
            isSkullPlaced = true;
        }

    }
}
