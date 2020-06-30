using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryButton : MonoBehaviour
{

    public Sprite enabledChip;

    // Start is called before the first frame update
    void Start()
    {
        UpdateReadStatus();
    }

    public void UpdateReadStatus() {
        // check if this is a new entry
        GameData gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        JournalEntry entry = GetComponent<ChangeView>().entry;

        bool[] entriesFound = gameData.EntriesFound;
        bool[] entriesOpened = gameData.EntriesOpened;

        int id = entry.id;
        if (!entriesFound[id] || (entriesFound[id] && entriesOpened[id])) {
            GetComponent<Text>().enabled = false;
        }

        GameObject button = transform.parent.gameObject;

        // adjust sprite
        if (entriesFound[id]) {
            button.GetComponent<Image>().sprite = enabledChip;
        } else {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
