using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighScore : MonoBehaviour
{
    public void UpdateHighScore() {
        GameData gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        GetComponent<Text>().text = "High Score: " + gameData.HighScore;
    }
}
