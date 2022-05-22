using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPillar : Interactable
{
    public static int numberOfActivePillars;
    bool isPillarActive = false;
    private int risingAnimation;
    [SerializeField] Animator animator;
    [SerializeField] Light[] lights;

    private void Awake()
    {
        risingAnimation = Animator.StringToHash("rising");
    }

    public override string GetDescription()
    {
        if (isPillarActive == false)
            return "Press [E] to activate";
        return "";
    }

    public override void Interact()
    {
        ActivatePillar();
    }

    void ActivatePillar()
    {
        if (isPillarActive == false)
        {
            isPillarActive = true;
            animator.SetTrigger(risingAnimation);
            numberOfActivePillars++;
            foreach (var light in lights)
            {
                light.enabled = true;
            }
        }
    }
}
