using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapManager : MonoBehaviour
{ 
    public static ArrowTrapManager instance { get; private set; }

    private void Awake()
    {
        instance = this;      
    }

    public void InstantiateArrow(GameObject arrow, Transform arrowPosition, Transform arrowPosition2)
    {
        Instantiate(arrow, arrowPosition.transform.position, arrowPosition.transform.localRotation);
        Instantiate(arrow, arrowPosition2.transform.position, arrowPosition2.transform.localRotation);
    }
}
