using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : Interactable
{
    
    public Animator animator;

    public override string GetDescription()
    {
        return "Press [E] to activate the elevator";
    }

    public override void Interact()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("elevatorIdle"))
            animator.SetTrigger("descending");
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("elevatorIdleDown"))
            animator.SetTrigger("ascending");
    }
}
