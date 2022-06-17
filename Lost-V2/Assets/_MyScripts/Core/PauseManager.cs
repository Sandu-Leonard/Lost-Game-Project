using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    [SerializeField] Image loadingProgressBar;

    public static bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuScreen;
    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private MonoBehaviour fpsControllerScript;
    [SerializeField] private AudioListener audioListener;

    private string mainMenuScene = "MainMenu";

    //AsyncOperation scene;
    //[Header("Graphics dropdown")]
    //[SerializeField] TMP_Dropdown dropDownQuality;

    //[Header("Sound")]
    //[SerializeField] TMP_Text volumeTextValue = null;
    //[SerializeField] Slider volumeSlider;

    //KEYS
    //private string masterVolumeKey = "MasterVolume";
    //private string qualitySettingKey = "QualitySetting";

    //private void Awake()
    //{
    //    LoadSettings();
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //}
    //public void SetQuality()
    //{
    //    int qualitySettingIndex = dropDownQuality.value;
    //    QualitySettings.SetQualityLevel(qualitySettingIndex);
    //    Debug.Log("value is " + qualitySettingIndex + " " + dropDownQuality.value);
    //    PlayerPrefs.SetInt(qualitySettingKey, qualitySettingIndex);
    //    PlayerPrefs.Save();
    //}

    //public void SetAudioLevel(float volume)
    //{
    //    AudioListener.volume = volume;
    //    volumeTextValue.text = volume.ToString("0.0");
    //}

    //public void VolumeApplyButton()
    //{
    //    PlayerPrefs.SetFloat(masterVolumeKey, AudioListener.volume);
    //}

    //void LoadSettings()
    //{
    //    if (PlayerPrefs.HasKey(qualitySettingKey))
    //        dropDownQuality.value = PlayerPrefs.GetInt(qualitySettingKey);
    //    if (PlayerPrefs.HasKey(masterVolumeKey))
    //        volumeSlider.value = PlayerPrefs.GetFloat(masterVolumeKey);
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenuScreen.SetActive(false);
        fpsControllerScript.enabled = true;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        gameIsPaused = false;
    }
    void PauseGame()
    {
        fpsControllerScript.enabled = false;
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;
    }

    public void MainMenuButton()
    {
        pauseMenuScreen.SetActive(false);
        //AudioListener.pause = false;
        //fpsControllerScript.enabled = true;
        Time.timeScale = 1f;
        //scenesToLoad.Add(SceneManager.LoadSceneAsync(mainMenuScene));
        //scene = SceneManager.LoadSceneAsync(mainMenuScene);
        //StartCoroutine(LoadingScreen());
        LoadingScreen();

    }
    public void ExitGameButton()
    {
        Application.Quit();
    }


    public async void LoadingScreen()
    {
        var scene = SceneManager.LoadSceneAsync(mainMenuScene);
        scene.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        while (scene.progress < 0.9f)
        {
            await System.Threading.Tasks.Task.Delay(100);
            loadingProgressBar.fillAmount = scene.progress;
        }
        scene.allowSceneActivation = true;
        //loadingScreen.SetActive(false);

    }

    //IEnumerator LoadingScreen()
    //{
    //    loadingScreen.SetActive(true);
    //    //float totalProgress = 0;
    //    //for (int i = 0; i < scenesToLoad.Count; i++)
    //    //{
    //    //    while (!scenesToLoad[i].isDone)
    //    //    {
    //    //        totalProgress += scenesToLoad[i].progress;
    //    //        loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
    //    //        yield return null;
    //    //    }
    //    //}
    //    while (scene.progress < 1f)
    //    {
    //        loadingProgressBar.fillAmount = scene.progress;
    //    }
    //    yield return null;

    //}


}

