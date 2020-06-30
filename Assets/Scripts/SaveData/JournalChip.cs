using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalChip : MonoBehaviour
{

    private int id;

    // Start is called before the first frame update
    void Start()
    {
        SetID();
    }

    private void SetID() {
        GameData gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        bool[] entriesFound = gameData.EntriesFound;

        List<int> possibleIDs = new List<int>();
        for (int i = 0; i < entriesFound.Length; i++) {
            if (!entriesFound[i]) {
                possibleIDs.Add(i);
            }
        }

        if (possibleIDs.Count > 0) {
            int index = (int)Random.Range(0f, possibleIDs.Count);
            id = possibleIDs[index];
        }
    }

    public int ID {
        get {
            return id;
        }
    }
}
