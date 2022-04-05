using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerWalls : MonoBehaviour
{

    public GameObject skull;
    public float smooth = 2f;

    public float xAxis = 0;
    public float yAxis = 0;
    public float zAxis = 0;

    void Update()
    {
        if (!skull.activeInHierarchy)
        {
            Quaternion targetRotation = Quaternion.Euler(xAxis, yAxis, zAxis);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime);
        }
    }
}
