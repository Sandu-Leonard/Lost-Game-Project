using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFromOneSide : Interactable
{
    private BoxCollider boxCollider;
    private Animator animator;
    private int openAnimation;
    private int closeAnimation;

    public CheckPositionToTheDoor checkPosition;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        openAnimation = Animator.StringToHash("Open");
        closeAnimation = Animator.StringToHash("Close");
    }
    public override string GetDescription()
    {
        if (checkPosition.canOpen)
            return "Press [E] to open the door.";
        else return "Can't be opened from this side.";
    }

    public override void Interact()
    {
        if (checkPosition.canOpen)
        {
            animator.SetTrigger(openAnimation);
            boxCollider.enabled = false;
        }
    }

}
