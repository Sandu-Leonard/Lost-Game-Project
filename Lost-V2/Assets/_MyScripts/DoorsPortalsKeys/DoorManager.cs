using System.Collections;
using UnityEngine;

public class DoorManager : Interactable
{
    [Header("Animations")]
    private Animator animator;
    private int openAnimationName;
    private int closeAnimationName;

    [Header("On hover text")]
    [SerializeField]
    private string textOnHoverCantOpen = "You need a key to open this door!";

    [SerializeField]
    private string textOnHoverCanOpen = "Press[E] to open";

    [SerializeField]
    private string noTextToShow = string.Empty;

    [Header("Audio")]
    [SerializeField]
    private AudioSource openSound;
    [SerializeField]
    private AudioSource closeSound;


    bool isOpen = false;
    bool hasKey = false;

    [Space(10)]
    public int index = -1;
    [Header("Timers")]
    [SerializeField]
    private float timeBeforeDoorCloses = 6;
    [SerializeField]
    private float timeBeforeDoorCanBeOpenedAgain = 2;

    private void Awake()
    {
        openAnimationName = Animator.StringToHash("Open");
        closeAnimationName = Animator.StringToHash("Close");
    }

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
        CheckIfHasKey();
    }
    void CheckIfHasKey()
    {
        if (PlayerInventory.keys[index] == true)
        {
            hasKey = true;
        }
    }
    public override string GetDescription()
    {
        if (isOpen == false && hasKey == false)
            return textOnHoverCantOpen;

        if (isOpen == false && hasKey)
            return textOnHoverCanOpen;
        return noTextToShow;
    }

    void OpenDoor()
    {
        if (hasKey && isOpen == false)
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
        yield return new WaitForSeconds(timeBeforeDoorCanBeOpenedAgain);
        isOpen = false;

    }
}
