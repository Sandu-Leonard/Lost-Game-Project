using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundEffects : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip onHover;
    [SerializeField]
    AudioClip onClick;


    public void OnHover()
    { 
        audioSource.PlayOneShot(onHover);
    }

    public void OnCick()
    {
        audioSource.PlayOneShot(onClick);
    }
}
