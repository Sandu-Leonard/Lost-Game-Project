using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneKeyPillarRising : MonoBehaviour
{
    [SerializeField] Animator animator;
    private int risingAnimation;
    [SerializeField] ParticleSystem flames;

    private void Awake()
    {
        risingAnimation = Animator.StringToHash("rising");
    }

    private void Update()
    {
        ActivateStonePillar();
    }
    void ActivateStonePillar()
    {
        if (RisingPillar.numberOfActivePillars == 2)
        {
            animator.SetTrigger(risingAnimation);
            flames.Play();
        }
    }


}
