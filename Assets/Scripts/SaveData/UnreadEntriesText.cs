using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnreadEntriesText : MonoBehaviour
{
    private int numUnread;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUnread();
    }

    public void UpdateUnread() 
    {
        GameData gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        numUnread = 0;

        bool[] entriesFound = gameData.EntriesFound;
        bool[] entriesOpened = gameData.EntriesOpened;

        for (int i = 0; i < entriesFound.Length; i++) {
            if (entriesFound[i] && !entriesOpened[i]) {
                numUnread++;
            }
        }

        Text unreadTxt = GetComponent<Text>();
        if (numUnread <= 0) {
            unreadTxt.enabled = false;
        } else {
            unreadTxt.text = numUnread.ToString();
            unreadTxt.enabled = true;
        }
    }
}
