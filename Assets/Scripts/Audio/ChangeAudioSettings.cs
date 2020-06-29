using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudioSettings : MonoBehaviour
{
    private Color ENABLED_COLOR = new Color(0.5960785f, 0.1254902f, 0.7176471f);
    private Color DISABLED_COLOR = new Color(0.4245283f, 0.4245283f, 0.4245283f);

    public GameObject musicText;
    public GameObject soundText;

    // audio manager
    private AudioManager am;

    void Start() {
        am = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();

        ChangeMusicLabel();
        ChangeSoundLabel();
    }

    public void ToggleMusic() {
        bool musicEnabled = am.MusicEnabled;
        if (musicEnabled) {
            am.DisableMusic();
        } else {
            am.EnableMusic();
        }
        
        ChangeMusicLabel();
    }

    public void ToggleSound() {
        am.ToggleSound();
        ChangeSoundLabel();
    }

    private void ChangeMusicLabel() {
        Text musicTxtCmpnt = musicText.GetComponent<Text>();

        if (am.MusicEnabled) {
            musicTxtCmpnt.text = "Music: ON";
            musicTxtCmpnt.color = ENABLED_COLOR;
        } else {
            musicTxtCmpnt.text = "Music: OFF";
            musicTxtCmpnt.color = DISABLED_COLOR;
        }
    }

    private void ChangeSoundLabel() {
        Text soundTxtCmpnt = soundText.GetComponent<Text>();

        if (am.SoundEnabled) {
            soundTxtCmpnt.text = "Sound: ON";
            soundTxtCmpnt.color = ENABLED_COLOR;
        } else {
            soundTxtCmpnt.text = "Sound: OFF";
            soundTxtCmpnt.color = DISABLED_COLOR;
        }
    }
}
