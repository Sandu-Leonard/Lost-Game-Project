using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : Interactable
{
    bool hasKey = false;
    public int index = -1;
    bool isOpen = false;
    [SerializeField]
    float doorOpenCloseSpeed = 2f;

    [Header("Rotations")]
    [SerializeField]
    float doorOpenAngle = 90f;
    [SerializeField]
    float doorCloseAngle = 0f;
    [SerializeField]
    float doorRotationXAxis = -90f;
    [SerializeField]
    float doorRotationYAxis = 0f;
    [SerializeField]
    float timeBeforeDoorCloses = 6f;



    public override string GetDescription()
    {
        if (!isOpen && !hasKey)
            return "You need a key to open this door!";

        if (!isOpen && hasKey)
            return "Press[E] to open.";
        return "";
    }

    public override void Interact()
    {
        OpenAndCloseDoor();
    }
    public void OpenAndCloseDoor()
    {
        if (PlayerInventory.keys[index] == true)
        {
            isOpen = true;
            StartCoroutine(AutoCloseDoor());          
        }    
    }

    private void Update()
    {
        if (PlayerInventory.keys[index] == true)
        {
            hasKey = true;
        }

        if (isOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(doorRotationXAxis, doorOpenAngle, doorRotationYAxis);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, doorOpenCloseSpeed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(doorRotationXAxis, doorCloseAngle, doorRotationYAxis);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, doorOpenCloseSpeed * Time.deltaTime);
        }
    }

    IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(timeBeforeDoorCloses);
        isOpen = false;
    }
}
