﻿using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;
    public bool loop;
    public bool interruptable;

    [HideInInspector]
    public AudioSource source;
}
