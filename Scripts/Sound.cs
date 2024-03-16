using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;
    //public bool isReady;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;

    public float GetAudioLength()
    {
        return clip.length;
    }
}
