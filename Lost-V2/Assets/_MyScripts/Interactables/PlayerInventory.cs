using UnityEngine;

public class PlayerInventory : MonoBehaviour
{   
    public static bool[] keys = new bool[10];

    private void Awake()
    {
        keys[0] = true;
    }

}
