using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    private const string RESCUED_TEXT = "Rescued: ";
    private Text rescuedText;

    private int numRescued;
    // Start is called before the first frame update
    void Start()
    {
        numRescued = 0;
        rescuedText = GetComponent<Text>();
        rescuedText.text = RESCUED_TEXT + numRescued;
    }

    public void IncreaseRescued() {
        numRescued++;
        rescuedText.text = RESCUED_TEXT + numRescued;
    }
}
