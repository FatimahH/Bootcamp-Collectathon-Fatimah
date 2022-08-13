using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioFiles[] sounds;

    void Awake()
    {
        foreach (AudioFiles sound in sounds)
        {

            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.playOnAwake = false;

        }
    }
    public void Play(string name)
    {
            AudioFiles sound = Array.Find(sounds, sound => sound.name == name);
            sound.source.Play();
    }

    public void PlayOneShot(string name)
    {

            AudioFiles sound = Array.Find(sounds, sound => sound.name == name);
            sound.source.PlayOneShot(sound.clip);
    }

}