using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSelection : Interactable
{
    bool cutsceneStarted = false;
    [SerializeField] MonoBehaviour fpsController;
    [SerializeField] GameObject missonsScreen;
    [SerializeField] BoxCollider mageBoxCollider;

    [Header("Collect Mission")]
    [SerializeField] GameObject collectMission;
    [Header("Break Mission")]
    [SerializeField] GameObject breakMission;
    [Header("Retrieve Mission")]
    [SerializeField] GameObject retrieveMission;
    [Space(10)]
    [SerializeField] GameObject isMissionOnScreen;

    public static bool isAnyMissonInProgress = false;

    public override string GetDescription()
    {
        if (cutsceneStarted == false)
            return "Press [E] to talk.";
        return "";
    }

    public override void Interact()
    {
        if (!cutsceneStarted)
        {
            ShowMissions();
        }
    }

    void ShowMissions()
    {
        mageBoxCollider.enabled = false;
        fpsController.enabled = false;
        missonsScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseButton()
    {
        mageBoxCollider.enabled = true;
        fpsController.enabled = true;
        missonsScreen.SetActive(false);
    }

    public void AcceptCollectMission()
    {
        if (!isAnyMissonInProgress)
        {
            mageBoxCollider.enabled = true;
            collectMission.SetActive(true);
            fpsController.enabled = true;
            isAnyMissonInProgress = true;
        }
        else
        {
            isMissionOnScreen.SetActive(true);
        }
    }
    public void AcceptBreakMission()
    {
        if (!isAnyMissonInProgress)
        {
            mageBoxCollider.enabled = true;
            breakMission.SetActive(true);
            fpsController.enabled = true;
            isAnyMissonInProgress = true;
        }
        else
        {
            isMissionOnScreen.SetActive(true);
        }
    }
    public void AcceptRetrieveMission()
    {
        if (!isAnyMissonInProgress)
        {
            mageBoxCollider.enabled = true;
            retrieveMission.SetActive(true);
            fpsController.enabled = true;
            isAnyMissonInProgress = true;
        }
        else
        {
            isMissionOnScreen.SetActive(true);
        }
    }
}
