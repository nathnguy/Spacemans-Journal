using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
            return;
        }

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }

        Play("Theme");
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(string name) {
        Sound audio = Array.Find(sounds, sound => sound.name == name);
        audio.source.Play();
    }
}
