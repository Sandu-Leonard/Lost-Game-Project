using System.Collections;
using UnityEngine;

public class ShowDialogueText : Interactable
{
    [SerializeField]
    float timerForDialogueDurationOnScreen = 5f;
    [SerializeField]
    GameObject uiDialogueText;
    public override string GetDescription()
    {
        return "Press [E] to interact.";
    }

    public override void Interact()
    {
        StartCoroutine(TextDisplayTimer());
    }

    IEnumerator TextDisplayTimer()
    {
        if (!isTextShown)
        {
            isTextShown = true;
            uiDialogueText.SetActive(true);
            yield return new WaitForSeconds(timerForDialogueDurationOnScreen);
            uiDialogueText.SetActive(false);
            isTextShown = false;
        }
    }
}
