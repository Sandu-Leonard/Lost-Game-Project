using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionSelection : Interactable
{
    bool cutsceneStarted = false;
    [SerializeField] GameObject isMissionOnScreen;

    [Header("Mission Status")]
    public GameObject collectMissionStatus;
    public GameObject breakMissionStatus;
    public GameObject completeMissionStatus;

    public static bool isAnyMissionInProgress = false;
    public static int numberOfCompletedMissions = 0;

    [SerializeField] UnityEvent showMissions;
    [SerializeField] UnityEvent acceptMission;
    [SerializeField] UnityEvent closeMissionPanel;
    [SerializeField] UnityEvent acceptCollectMission;
    [SerializeField] UnityEvent acceptBreakMission;
    [SerializeField] UnityEvent acceptGoToTheMageMission;
    [SerializeField] UnityEvent acceptLeaveTheDungeonMission;

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
        showMissions.Invoke();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseButton()
    {
        closeMissionPanel.Invoke();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AcceptCollectMission()
    {
        if (!isAnyMissionInProgress)
        {
            AcceptMission();
            acceptCollectMission.Invoke();
        }
        else
            ActivateIsMissionOnScreen();

    }
    public void AcceptBreakMission()
    {
        if (!isAnyMissionInProgress)
        {
            AcceptMission();
            acceptBreakMission.Invoke();           
        }
        else
            ActivateIsMissionOnScreen();
    }

    public void AcceptGoToTheMageMission()
    {
        acceptMission.Invoke();
        acceptGoToTheMageMission.Invoke();
        isAnyMissionInProgress = true;
        DialogueFilipStart.selectMissionOn = true;
    }
    public void AceeptLeaveTheDungeonMission()
    {
        acceptMission.Invoke();
        acceptLeaveTheDungeonMission.Invoke();
        isAnyMissionInProgress = true;
        DialogueFilipStart.selectMissionOn = true;
    }
    void AcceptMission()
    {
        acceptMission.Invoke();
        isAnyMissionInProgress = true;
    }

    void ActivateIsMissionOnScreen()
    {
        isMissionOnScreen.SetActive(true);
    }


}
