using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{

    public GameObject menu;
    //public GameObject loadingInterface;
    //public Image loadfingProgressBar;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();


    // Start is called before the first frame update
    public void StartGame()
    {
        HideMenu();
        ShowLoadingScreen();
        //Load the Scene asynchronously in the background
        scenesToLoad.Add(SceneManager.LoadSceneAsync("GameplayScene"));
        //Additive mode adds the Scene to the current loaded Scenes, in this case Gameplay scene
        scenesToLoad.Add(SceneManager.LoadSceneAsync("DungeonEntrancePart", LoadSceneMode.Additive));
       // StartCoroutine(LoadingScreen());
    }

    public void ShowLoadingScreen()
    { 
        
    }

    private void HideMenu()
    {
        menu.SetActive(false);
    }


}
