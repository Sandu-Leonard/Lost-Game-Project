using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateScenes : MonoBehaviour
{
    [SerializeField] private GameObject[] scenes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisableEnableScenes());            
        }
    }

    IEnumerator DisableEnableScenes()
    {
        SceneManager.UnloadSceneAsync("TerrainScene");
        SceneManager.UnloadSceneAsync("IntroPart");
        yield return null;
        foreach (var scene in scenes)
        {
            scene.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);

    }
}
