using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TorchInteractable : Interactable
{
    [SerializeField]
    UnityEvent pickupTorch;

    public override string GetDescription()
    {
        return "Press [E] to pick up torch";
    }

    public override void Interact()
    {
        pickupTorch.Invoke();
    }

}
