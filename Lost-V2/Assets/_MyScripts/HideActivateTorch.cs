using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideActivateTorch : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    [SerializeField] TorchInteractable torchInteractable;

    private bool isTorchInHand = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && torchInteractable.canHideTorch)
        {
            if (isTorchInHand == true)
            {
                HideTorch();
            }
            else
            {
                ShowTorch();
            }
            isTorchInHand = !isTorchInHand;
        }
        
    }

    void ShowTorch()
    { 
        torch.SetActive(true);
    }

    void HideTorch()
    {
        torch.SetActive(false);
    }
}
