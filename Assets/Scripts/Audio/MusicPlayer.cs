using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public string songName;

    // Start is called before the first frame update
    void Start()
    {
        GameObject am = GameObject.FindWithTag("Audio");
        am.GetComponent<AudioManager>().Play(songName);
    }
}
