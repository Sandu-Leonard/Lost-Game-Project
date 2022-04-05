using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPieceInteractable : Interactable
{
    public static int numberOfBrokenPieces;
    [SerializeField]
    GameObject woodPiece;

    [SerializeField]
    GameObject crowbar;

    public override string GetDescription()
    {
        if (crowbar.activeInHierarchy)
            return "Press [E] to break";
        else
            return "You need something to break this with.";
    }

    public override void Interact()
    {
        BreakWoodPieces(); 
    }

    void BreakWoodPieces()
    {
        if (crowbar.activeInHierarchy)
        {
            gameObject.SetActive(false);
            woodPiece.SetActive(true);
            numberOfBrokenPieces++;
        }
    }
}
