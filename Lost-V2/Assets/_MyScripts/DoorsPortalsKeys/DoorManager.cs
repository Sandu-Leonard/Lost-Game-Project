using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : Interactable
{
    [Header("Animations")]
    Animator animator;
    [SerializeField] string openAnimationName = "Open";
    [SerializeField] string closeAnimationName = "Close";

    [Header("On hover text")]
    [SerializeField] string textOnHoverCantOpen = "You need a key to open this door!";
    [SerializeField] string textOnHoverCanOpen = "Press[E] to open";
    [SerializeField] string noTextToShow = "";

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
            return textOnHoverCantOpen;

        if (!isOpen && hasKey)
            return textOnHoverCanOpen;
        return noTextToShow;
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
