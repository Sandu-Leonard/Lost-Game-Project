using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionDisplay : MonoBehaviour
{
    public MissionStatus missionStatus;
    public TMP_Text text;

    private void Update()
    {
        if (TorchInteractable.interacted)
        {
            text.text = missionStatus.missionDescription.ToString();
        }
    }
}
