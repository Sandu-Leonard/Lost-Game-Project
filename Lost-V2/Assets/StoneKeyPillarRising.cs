using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneKeyPillarRising : MonoBehaviour
{
    [SerializeField] Animator animator;
    string risingAnimation = "rising";
    [SerializeField] ParticleSystem flames;

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
