using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;
    
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    public bool isMusic;
    private bool isPlaying;

    [HideInInspector]
    public AudioSource source; 

    public bool IsPlaying {
        get {
            return isPlaying;
        }

        set {
            isPlaying = value;
        }
    }

}
