using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteractable : Interactable
{
    [SerializeField]
    GameObject playerTorch;
    public static bool interacted;

    public override string GetDescription()
    {
        return "Press [E] to pick up torch";
    }

    public override void Interact()
    {
        interacted = true;
        gameObject.SetActive(false);
        playerTorch.gameObject.SetActive(true);
    }

}
