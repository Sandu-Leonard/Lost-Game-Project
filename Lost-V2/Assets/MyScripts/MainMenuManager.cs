using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string gameLevelScene;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject loadingInterface;
    [SerializeField] Image loadingProgressBar;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public void StartGameYesButton()
    {
        HideMenu();
        //SceneManager.LoadScene(gameLevelScene);
        ShowLoadingScreen();
        //Load the Scene asynchronously in the background
        scenesToLoad.Add(SceneManager.LoadSceneAsync(gameLevelScene));
        //Additive mode adds the Scene to the current loaded Scenes, in this case Gameplay scene
        scenesToLoad.Add(SceneManager.LoadSceneAsync("DungeonEntrancePart", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
    }

    public void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
    }

    IEnumerator LoadingScreen()
    {
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
}
