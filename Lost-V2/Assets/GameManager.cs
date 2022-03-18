using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Awake()
    {
        //Load();
    }

    public void Save()
    {
        Vector3 playerPosition = player.transform.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
        PlayerPrefs.Save();
        print(playerPosition.x + " " + playerPosition.y + " " + playerPosition.z + " Saved");
    }

    public void Load()
    {

        if (PlayerPrefs.HasKey("playerPositionX"))
        {
            float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
            float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
            float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
            Vector3 playerPostion = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
            print(playerPositionX + " " + playerPositionY + " " + playerPositionZ + " Loaded");

            player.transform.position = playerPostion;
        }
        else
        {
            print("No save");
        }
    }

    private void OnApplicationQuit()
    {
        //Save();
    }

}

