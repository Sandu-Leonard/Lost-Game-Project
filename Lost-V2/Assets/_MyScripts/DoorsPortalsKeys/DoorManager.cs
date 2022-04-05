using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : Interactable
{
    [Header("Animations")]
    Animator animator;
    string openAnimationName = "Open";
    string closeAnimationName = "Close";

    [Header("Audio")]
    [SerializeField] AudioSource openSound;
    [SerializeField] AudioSource closeSound;

    bool isOpen = false;
    bool hasKey = false;

    [Space(10)]
    public int index = -1;
    [SerializeField] float timeBeforeDoorCloses = 6;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        OpenDoor();    
    }

    private void Update()
    {
        if (PlayerInventory.keys[index] == true)
        {
            hasKey = true;
        }
    } 

    public override string GetDescription()
    {
        if (!isOpen && !hasKey)
            return "You need a key to open this door!";

        if (!isOpen && hasKey)
            return "Press[E] to open.";
        return "";
    }

    void OpenDoor()
    {
        if (hasKey && !isOpen)
        {
            animator.SetTrigger(openAnimationName);
            openSound.Play();
            isOpen = true;
            StartCoroutine(AutoCloseDoor());
        }
    }

    IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(timeBeforeDoorCloses);
        animator.SetTrigger(closeAnimationName);
        closeSound.Play();
        yield return new WaitForSeconds(2);
        isOpen = false;
    }
}
