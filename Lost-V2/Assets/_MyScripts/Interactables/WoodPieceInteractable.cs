using UnityEngine;
using TMPro;

public class WoodPieceInteractable : Interactable
{
    [SerializeField] GameObject woodPiece;
    [SerializeField] TMP_Text missionStatus;
    public override string GetDescription()
    {
        return "Press [E] to break";
    }

    public override void Interact()
    {
        BreakWoodPieces();
    }

    void BreakWoodPieces()
    { 
        gameObject.SetActive(false);
        woodPiece.SetActive(true);
        BreakMission.numberOfBrokenPieces--;
        missionStatus.text = $"{BreakMission.numberOfBrokenPieces} left";
    }
}

