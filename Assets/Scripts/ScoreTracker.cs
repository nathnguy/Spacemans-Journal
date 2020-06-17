using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public GameObject distance;
    public GameObject spaceman;

    private const string RESCUED_TEXT = "Rescued: ";
    private Text rescuedText;

    private float initialPos;
    private int mostTraveled;

    private int numRescued;
    // Start is called before the first frame update
    void Start()
    {
        numRescued = 0;
        rescuedText = GetComponent<Text>();
        rescuedText.text = RESCUED_TEXT + numRescued;

        initialPos = spaceman.transform.position.y;
    }

    void Update() {
        CalcDistance();
    }

    void CalcDistance() {
        int traveled = (int)(spaceman.transform.position.y - initialPos) * 2;
        mostTraveled = traveled > mostTraveled ? traveled : mostTraveled;
        distance.GetComponent<Text>().text = "" + mostTraveled + " m";
    }

    public void IncreaseRescued() {
        numRescued++;
        rescuedText.text = RESCUED_TEXT + numRescued;
    }

    public int NumRescued {
        get {
            return numRescued;
        }
    }

    public int DistanceTraveled {
        get {
            return mostTraveled;
        }
    }
}
