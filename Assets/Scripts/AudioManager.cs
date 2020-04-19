using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public Sound[] sounds;

    private void Awake()
    {
        EnsureOnlyOneInstance();
        CreateAudioSourceForEachSound();
    }

    private void CreateAudioSourceForEachSound()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            //s.source.pitch = UnityEngine.Random.Range(.9f, 1.1f);
            s.source.pitch = 1f;
        }
    }

    private void EnsureOnlyOneInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //s.source.pitch = UnityEngine.Random.Range(.9f, 1.1f);
        s.source.Play();
    }
}
