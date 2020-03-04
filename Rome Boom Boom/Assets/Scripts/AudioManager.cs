using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager audioManager;
    private void Awake()
    {

        if (!audioManager)
        {
            audioManager = this;
        }
        else
        {
            Destroy(this);
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
    }


    void Update()
    {
        
    }

    public void PlaySound(string Name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == Name);
        s.source.Play();
    }
}
