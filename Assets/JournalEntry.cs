using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Journal Entry", menuName = "Journal Entry")]
public class JournalEntry : ScriptableObject
{
    public int id;

    public string date;

    [TextArea]
    public string entry;
}
