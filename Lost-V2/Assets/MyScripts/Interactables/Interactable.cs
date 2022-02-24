using UnityEngine;
public abstract class Interactable : MonoBehaviour
{
    public static bool isTextShown;
    public static bool isObjectiveShown;
    public enum InteractionType
    {
        onKeyPress,
        openCloseDoor
    }

    public InteractionType interactionType;

    public abstract string GetDescription();
    public abstract void Interact();
}