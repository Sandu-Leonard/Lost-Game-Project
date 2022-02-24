using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueLine : DialogueBase
{
    
    [SerializeField]
    string input;
    TMP_Text textHolder;

    [SerializeField]
    float delay = 0.3f;
    [SerializeField]
    float delayBetweenLines = 2f;
    [SerializeField]
    AudioClip sound;

    [Header("Character name")]
    [SerializeField]
    string characterName;
    [SerializeField]
    TMP_Text characterNameHolder;


    private void Awake()
    {
        textHolder = GetComponent<TMP_Text>();
        textHolder.text = "";
        characterNameHolder.text = characterName;
    }

    private void Start()
    {
        StartCoroutine(WriteText(input, textHolder, delay, sound, delayBetweenLines));
    }
}
