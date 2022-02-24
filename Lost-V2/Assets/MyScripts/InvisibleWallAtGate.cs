using UnityEngine;
using TMPro;
public class InvisibleWallAtGate : Interactable
{
    [SerializeField]
    GameObject textToShow;

    [SerializeField]
    GameObject playerTorch;


    private void Update()
    {
        DeactivateInvisibleWall();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isTextShown)
        {
            textToShow.SetActive(true);
            isTextShown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textToShow.SetActive(false);
            isTextShown = false;
        }
    }

    void DeactivateInvisibleWall()
    {
        if (playerTorch.activeInHierarchy == true)
        {          
            gameObject.SetActive(false);
        }
    }

    public override string GetDescription()
    {
        return "";
    }

    public override void Interact()
    {
        
    }
}
