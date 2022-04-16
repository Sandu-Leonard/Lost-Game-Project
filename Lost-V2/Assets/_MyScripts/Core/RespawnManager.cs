using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager instance;
    public Vector3 lastCheckpointPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        { 
            Destroy(gameObject);
        }

    }
}
