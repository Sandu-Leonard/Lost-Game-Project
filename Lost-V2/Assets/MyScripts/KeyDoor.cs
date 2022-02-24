using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    
    [SerializeField]
    bool isOpen = false;
    [SerializeField]
    float doorOpenAngleZ = 90f;
    [SerializeField]
    float doorCloseAngleZ = 0f;
    [SerializeField]
    float smooth = 2f;
    [SerializeField]
    float doorRotationXAxis = -90f;
    [SerializeField]
    float doorRotationYAxis = 0f;

    public void OpenCloseDoor()
    {
        isOpen = !isOpen;
    }

    private void Update()
    {
        if (isOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(doorRotationXAxis, doorRotationYAxis, doorOpenAngleZ);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(doorRotationXAxis, doorRotationYAxis, doorCloseAngleZ);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }

    

}
