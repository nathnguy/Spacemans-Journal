using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public bool[] entriesFound;
    public bool[] entriesOpened;
    public int highScore;
    
    public SaveData(GameData gameData) {
        entriesFound = gameData.EntriesFound;
        entriesOpened = gameData.EntriesOpened;
        highScore = gameData.HighScore;
    }
}
