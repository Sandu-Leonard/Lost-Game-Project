using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapTrigger : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] Transform arrowPositionRight;
    [SerializeField] Transform arrowPositionLeft;

    private string playerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            ArrowTrapManager.instance.InstantiateArrow(arrow, arrowPositionRight, arrowPositionLeft);
        }
    }
}
