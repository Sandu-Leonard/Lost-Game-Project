using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionStatusUpdate : MonoBehaviour
{
    public static bool interacted;
    [SerializeField]
    GameObject missionStatus;
    [SerializeField]
    GameObject interactable;

    private void Update()
    {
        if (interacted)
        {
            missionStatus.SetActive(true);
        }
    }


}
