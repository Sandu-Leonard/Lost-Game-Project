using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundEffects : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip onHover;
    [SerializeField]
    private AudioClip onClick;


    public void OnHover()
    { 
        audioSource.PlayOneShot(onHover);
    }

    public void OnCick()
    {
        audioSource.PlayOneShot(onClick);
    }
}
