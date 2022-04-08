using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSelection : Interactable
{
    bool cutsceneStarted = false;
    [SerializeField] MonoBehaviour fpsController;
    [SerializeField] BoxCollider mageBoxCollider;
    [SerializeField] GameObject missionsPanel;

    [Header("Collect Mission")]
    [SerializeField] GameObject collectMission;
    [Header("Break Mission")]
    [SerializeField] GameObject breakMission;
    [Space(10)]
    [SerializeField] GameObject isMissionOnScreen;
    [Space(10)]
    [SerializeField] GameObject basementKey;

    public GameObject collectMissionStatus;
    public GameObject breakMissionStatus;
    public GameObject completeMissionStatus;

    public static bool isAnyMissionInProgress = false;
    public static int numberOfCompletedMissions = 0;

    public override string GetDescription()
    {
        if (cutsceneStarted == false)
            return "Press [E] to talk.";
        return "";
    }

    public override void Interact()
    {
        if (!cutsceneStarted)
            ShowMissions();
    }


    void ShowMissions()
    { 
        mageBoxCollider.enabled = false;
        fpsController.enabled = false;
        missionsPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseButton()
    {
        mageBoxCollider.enabled = true;
        fpsController.enabled = true;
    }

    public void AcceptCollectMission()
    {
        if (!isAnyMissionInProgress)
        {
            AcceptMission();
            collectMission.SetActive(true);
            collectMissionStatus.SetActive(true);
        }
        else
            ActivateIsMissionOnScreen();

    }
    public void AcceptBreakMission()
    {
        if (!isAnyMissionInProgress)
        {
            AcceptMission();
            basementKey.SetActive(true);
            breakMissionStatus.SetActive(true);
            breakMission.SetActive(true);
        }
        else
            ActivateIsMissionOnScreen();
    }
    void AcceptMission()
    {
        mageBoxCollider.enabled = true;
        fpsController.enabled = true;
        isAnyMissionInProgress = true;
    }

    void ActivateIsMissionOnScreen()
    {
        isMissionOnScreen.SetActive(true);
    }


}
