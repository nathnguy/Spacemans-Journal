using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    private const int NUM_ENTRIES = 22;

    // journal data
    private bool[] entriesFound;
    private bool[] entriesOpened;

    // score data
    private int highScore;


    void Awake() {
        // default values
        entriesFound = new bool[NUM_ENTRIES];
        entriesOpened = new bool[NUM_ENTRIES];
        highScore = 0;

        // load save data
        SaveData data = SaveSystem.LoadGame();
        if (data == null) {
            SaveGameData();
        } else {
            entriesFound = data.entriesFound;
            entriesOpened = data.entriesOpened;
            highScore = data.highScore;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveGameData() {
        SaveSystem.SaveGame(this);
    }

    public void AddFoundEntry(int id) {
        entriesFound[id] = true;
    }

    public void AddOpenedEntry(int id) {
        entriesOpened[id] = true;
    }

    public void UpdateHighScore(int score) {
        highScore = score > highScore ? score : highScore;
    }

    // getter methods

    public bool[] EntriesFound {
        get {
            return entriesFound;
        }
    }

    public bool[] EntriesOpened {
        get {
            return entriesOpened;
        }
    }

    public int HighScore {
        get {
            return highScore;
        }
    }
}
