using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string gameLevelScene;
    [SerializeField] MonoBehaviour fpsControllerScript;
    [SerializeField] GameObject menu;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    [Header("Loading Screen")]
    [SerializeField] GameObject loadingInterface;
    [SerializeField] Image loadingProgressBar;
    
    [Header("Graphics dropdown")]
    [SerializeField] TMP_Dropdown dropDownQuality;

    [Header("Sound")]
    [SerializeField] TMP_Text volumeTextValue = null;
    [SerializeField] Slider volumeSlider;

    

    private void Awake()
    {
        PlayerPrefs.GetInt("QualitySetting");
    }

    public void StartGameYesButton()
    {
        HideMenu();
        PlayerPrefs.GetFloat("MasterVolume");
        //Load the Scene asynchronously in the background
        scenesToLoad.Add(SceneManager.LoadSceneAsync(gameLevelScene));
        ////Additive mode adds the Scene to the current loaded Scenes, in this case Gameplay scene
        scenesToLoad.Add(SceneManager.LoadSceneAsync("TerrainScene", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());     
    }


    IEnumerator LoadingScreen()
    {
        loadingInterface.SetActive(true);
        float totalProgress = 0;
        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {              
                totalProgress += scenesToLoad[i].progress;
                loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }      
    }

    private void HideMenu()
    {
        menu.SetActive(false);
    }

    public void ExitGameYesButton()
    {
        Application.Quit();
    }

    public void SetQuality()
    {
        int qualitySettingIndex = dropDownQuality.value;
        QualitySettings.SetQualityLevel(qualitySettingIndex);
        Debug.Log("value is " + qualitySettingIndex + " " + dropDownQuality.value);
        PlayerPrefs.SetInt("QualitySetting", qualitySettingIndex);
        PlayerPrefs.Save();
    }

    public void SetAudioLevel(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApplyButton()
    {
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        PlayerPrefs.Save();
    }

}
