using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeView : MonoBehaviour
{

    public JournalEntry entry;
    
    public GameObject entryView;
    public GameObject selectView;

    public void EntryView() {
        selectView.SetActive(false);
        entryView.SetActive(true);

        GameObject entryText = GameObject.FindWithTag("EntryText");
        GameObject entryDate = GameObject.FindWithTag("EntryDate");

        entryText.GetComponent<Text>().text = entry.entry;
        entryDate.GetComponent<Text>().text = entry.date;

        MarkAsRead();
    }

    private void MarkAsRead() {
        GameData gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        gameData.AddOpenedEntry(entry.id);
        SaveSystem.SaveGame(gameData);
    }

    public void SelectView() {
        entryView.SetActive(false);
        selectView.SetActive(true);
    }
}
