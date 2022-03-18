using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TorchInteractable : Interactable
{
    [SerializeField]
    GameObject playerTorch;

    [SerializeField]
    UnityEvent pickupTorch;
    public static bool interacted;

    public override string GetDescription()
    {
        return "Press [E] to pick up torch";
    }

    public override void Interact()
    {
        interacted = true;
        pickupTorch.Invoke();
    }

}
