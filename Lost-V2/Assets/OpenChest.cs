using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : Interactable
{
    private Animator animator;
    private BoxCollider boxCollider;
    private int openLidAnim;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponentInChildren<Animator>();
        openLidAnim = Animator.StringToHash("openLid");
    }
    public override string GetDescription()
    {
        return "Press [E] to open.";
    }

    public override void Interact()
    {
        OpenChestLid();
    }

    private void OpenChestLid()
    {      
        animator.SetTrigger(openLidAnim);
        boxCollider.enabled = false;
    }
}
