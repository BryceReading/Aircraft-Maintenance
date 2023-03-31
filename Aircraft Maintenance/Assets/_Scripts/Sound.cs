using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    public Settings settings;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.volume = settings.s_sound;
    }

    public void ButtonSound()
    {
        audioSource.volume = settings.s_sound;
        audioSource.Play();
    }
}
