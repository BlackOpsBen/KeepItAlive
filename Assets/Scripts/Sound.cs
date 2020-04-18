using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    //[Range(.9f, 1.1f)]
    //public float pitch;

    [HideInInspector]
    public AudioSource source;
}
