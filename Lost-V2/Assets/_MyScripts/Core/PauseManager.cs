using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] GameObject pauseMenuScreen;
    [SerializeField] MonoBehaviour fpsControllerScript;
    [SerializeField] AudioListener audioListener;

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
        AudioListener.pause = true;
        gameIsPaused = true;
    }

    public void MainMenuButton()
    {
        pauseMenuScreen.SetActive(false);
        AudioListener.pause = false;
        fpsControllerScript.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
        
}

