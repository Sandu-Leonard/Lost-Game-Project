using UnityEngine;

public class KeyScript : Interactable
{
    public int keyIndex = -1;

    public override string GetDescription()
    {
        return "Pick up Key";
    }

    public override void Interact()
    {
        gameObject.SetActive(false);
        PlayerInventory.keys[GetComponent<KeyScript>().keyIndex] = true;
    }
}
