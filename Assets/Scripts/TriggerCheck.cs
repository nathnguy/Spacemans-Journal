using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TriggerCheck : MonoBehaviour
{
    public GameObject resultTitle;

    public GameObject st;

    private ScoreTracker increaseRescued;
    private SpacemanMovement sm;
    private AudioManager am;


    // Start is called before the first frame update
    void Start()
    {
        increaseRescued = st.GetComponent<ScoreTracker>();
        sm = GetComponent<SpacemanMovement>();
        am = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Person")) {
            am.Play("Collect");
            increaseRescued.IncreaseRescued();
        } else if (other.CompareTag("Slow")) {
            am.Play("Slow");
            sm.SpeedDebuff();
        } else if (other.CompareTag("Asteroid")) {
            resultTitle.GetComponent<Text>().text = "Hit by an Asteroid...";
            GameObject.FindWithTag("Endgame").GetComponent<EndGame>().ShowResults();
        }
        Destroy(other.gameObject);
    }
}
