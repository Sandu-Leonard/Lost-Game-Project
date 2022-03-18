using UnityEngine;
using TMPro;
public class InvisibleWallAtGate : MonoBehaviour
{
    [SerializeField]
    GameObject textToShow;

    [SerializeField]
    GameObject playerTorch;

    string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag && !Interactable.isTextShown)
        {
            textToShow.SetActive(true);
            Interactable.isTextShown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
            textToShow.SetActive(false);
            Interactable.isTextShown = false;
        }
    }

}
