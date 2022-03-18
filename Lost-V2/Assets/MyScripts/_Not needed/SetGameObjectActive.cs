using UnityEngine;

public class SetGameObjectActive : MonoBehaviour
{
    [SerializeField]
    GameObject missionText;

    private void OnTriggerEnter(Collider other)
    {
        missionText.SetActive(true);
    }
}

