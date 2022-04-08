using UnityEngine;

public class SphereInteract : Interactable
{
    [SerializeField] GameObject sphereLight;
    [SerializeField] GameObject rockKey;
    bool isSphereOn = false;
    bool pressed = false;

    Animator animator;
    Renderer rend;

    string animationParameter = "bounce";
    string emission = "_EMISSION";

    private void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
    }
    public override string GetDescription()
    {
        if (!isSphereOn && !rockKey.activeInHierarchy)
            return "Press [E] to activate!";
        else 
            return "";
    }

    public override void Interact()
    {
        ActivateSphere();       
    }

    private void ActivateSphere()
    {
        if (!pressed && !rockKey.activeInHierarchy)
        {
            pressed = true;
            OpenDoorToPart2.numberOfActiveSpheres++;
            isSphereOn = true;
            rend.material.EnableKeyword(emission);
            sphereLight.SetActive(true);
            animator.SetTrigger(animationParameter);
            
        }
    }

}
