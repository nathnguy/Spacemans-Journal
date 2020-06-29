using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private bool musicEnabled;
    private bool soundEnabled;

    private string currentSong;

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

        currentSong = null;
        musicEnabled = true;
        soundEnabled = true;

        //Play("Theme");
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(string name) {
        Sound audio = Array.Find(sounds, sound => sound.name == name);

        if (audio.isMusic && currentSong != null && name != currentSong) {
            Sound oldAudio = Array.Find(sounds, sound => sound.name == currentSong);
            oldAudio.source.Stop();
            oldAudio.IsPlaying = false;
        }

        if (audio.isMusic && musicEnabled && !audio.IsPlaying) {
            audio.source.Play();
            currentSong = name;
            audio.IsPlaying = true;
        } else if (!audio.isMusic && soundEnabled) {
            audio.source.Play();
        }
    }

    public void DisableMusic() {
        Sound audio = Array.Find(sounds, sound => sound.name == currentSong);
        audio.source.Stop();
        audio.IsPlaying = false;
        musicEnabled = false;
    }

    public void EnableMusic() {
        Play(currentSong);
        musicEnabled = true;
    }

    public void ToggleSound() {
        soundEnabled = !soundEnabled;
    }

    public bool MusicEnabled {
        get {
            return musicEnabled;
        }
    }

    public bool SoundEnabled {
        get {
            return soundEnabled;
        }
    }
}
