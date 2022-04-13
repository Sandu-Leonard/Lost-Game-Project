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
        LoadSettings();
    }

    public void StartGameYesButton()
    {
        HideMenu();
        //ShowLoadingScreen();
        PlayerPrefs.GetFloat("MasterVolume");
        //scenesToLoad.Add(SceneManager.UnloadSceneAsync("MainMenu"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync(gameLevelScene));
       // scenesToLoad.Add(SceneManager.LoadSceneAsync("TerrainScene", LoadSceneMode.Additive));
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("IntroPart", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());

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
    }

    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("QualitySetting"))
            dropDownQuality.value = PlayerPrefs.GetInt("QualitySetting");
        if (PlayerPrefs.HasKey("MasterVolume"))
            volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
    }

    IEnumerator LoadingScreen()
    {
        loadingInterface.SetActive(true);
        //float totalProgress = 0;
        //for (int i = 0; i < scenesToLoad.Count; i++)
        //{
        //    while (!scenesToLoad[i].isDone)
        //    {
        //        totalProgress = 0;
        //        foreach (AsyncOperation operation in scenesToLoad)
        //        {
        //            totalProgress += operation.progress;
        //        }
        //        totalProgress = (totalProgress / scenesToLoad.Count);
        //        loadingProgressBar.fillAmount = Mathf.RoundToInt(totalProgress);
        //        yield return null;
        //    }

        //}
        //loadingInterface.SetActive(false); 
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

  
}
