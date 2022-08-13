using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class AudioFiles
{

    public string name;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
    [Range(.1f, 1f)]
    public float volume;


}