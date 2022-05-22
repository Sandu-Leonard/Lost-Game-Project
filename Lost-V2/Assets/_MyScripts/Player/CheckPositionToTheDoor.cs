using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPositionToTheDoor : MonoBehaviour
{
    [SerializeField]
    private Transform door;
    [SerializeField]
    private float doorDistance = 5f;
    [SerializeField]
    float openDoorOffest = 0.2f;
    public bool canOpen;

    private void Update()
    {
        Vector3 dirFromPlayerToDoor = (transform.position - door.position).normalized;
        float dot = Vector3.Dot(door.forward, dirFromPlayerToDoor);

        if (dot < openDoorOffest && Vector3.Distance(transform.position, door.position) < doorDistance)
        {           
            canOpen = true;
        }
        else
            canOpen = false;
    }
}
