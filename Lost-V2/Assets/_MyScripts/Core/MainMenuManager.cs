using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainMenuManager : MonoBehaviour
{

    //SCENES
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    [SerializeField] private string gameLevelScene;

    [SerializeField] GameObject menu;
    
    [Header("Loading Screen")]
    [SerializeField] GameObject loadingInterface;
    [SerializeField] Image loadingProgressBar;

    [Header("Graphics dropdown")]
    [SerializeField] TMP_Dropdown dropDownQuality;

    [Header("Sound")]
    [SerializeField] TMP_Text volumeTextValue = null;
    [SerializeField] Slider volumeSlider;

    //KEYS
    private string masterVolumeKey = "MasterVolume";
    private string qualitySettingKey = "QualitySetting";

    private void Awake()
    {
        LoadSettings();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGameYesButton()
    {
        HideMenu();
        //ShowLoadingScreen();
        PlayerPrefs.GetFloat(masterVolumeKey);
        
        scenesToLoad.Add(SceneManager.LoadSceneAsync(gameLevelScene));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("TerrainScene", LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("IntroPart", LoadSceneMode.Additive));
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
        PlayerPrefs.SetInt(qualitySettingKey, qualitySettingIndex);
        PlayerPrefs.Save();
    }

    public void SetAudioLevel(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApplyButton()
    {
        PlayerPrefs.SetFloat(masterVolumeKey, AudioListener.volume);
    }

    void LoadSettings()
    {
        if (PlayerPrefs.HasKey(qualitySettingKey))
            dropDownQuality.value = PlayerPrefs.GetInt(qualitySettingKey);
        if (PlayerPrefs.HasKey(masterVolumeKey))
            volumeSlider.value = PlayerPrefs.GetFloat(masterVolumeKey);
    }

    void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
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

  
}
