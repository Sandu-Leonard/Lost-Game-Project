using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoToTheMageMission : MonoBehaviour
{
    [SerializeField]
    UnityEvent goToTheMageEvent;

    private void Update()
    {
        goToTheMageEvent.Invoke();
    }

}
