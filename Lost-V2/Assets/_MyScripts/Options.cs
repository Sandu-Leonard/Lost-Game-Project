using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    //SCENES


    [Header("Graphics dropdown")]
    [SerializeField] TMP_Dropdown dropDownQuality;

    [Header("Sound")]
    [SerializeField] TMP_Text volumeTextValue = null;
    [SerializeField] Slider volumeSlider;

    //KEYS
    private string masterVolumeKey = "MasterVolume";
    private string qualitySettingKey = "QualitySetting";

    //private void Awake()
    //{
    //    LoadSettings();
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //}
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
}
