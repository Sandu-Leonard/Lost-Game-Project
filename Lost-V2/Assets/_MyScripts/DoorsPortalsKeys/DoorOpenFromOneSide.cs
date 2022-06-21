using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFromOneSide : Interactable
{
    private static DoorOpenFromOneSide instance;
    private BoxCollider boxCollider;
    private Animator animator;
    private int openAnimation;

    public CheckPositionToTheDoor checkPosition;

    [Header("Audio")]
    [SerializeField]
    private AudioSource openSound;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        openAnimation = Animator.StringToHash("Open");
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
            openSound.Play();
            animator.SetTrigger(openAnimation);
            boxCollider.enabled = false;
        }
    }

}
