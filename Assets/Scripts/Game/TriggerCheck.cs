using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TriggerCheck : MonoBehaviour
{
    public GameObject resultTitle;

    public GameObject st;

    public string[] rescueMsgs;
    public GameObject rescueMsg;
    public GameObject renderCanvas;

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
            DisplayRescueMsg(other.gameObject.transform.position);
        } else if (other.CompareTag("Chip")) {
            am.Play("Collect");
        } else if (other.CompareTag("Slow")) {
            am.Play("Slow");
            sm.SpeedDebuff();
        } else if (other.CompareTag("Asteroid")) {
            am.Play("Explosion");
            resultTitle.GetComponent<Text>().text = "Hit by an Asteroid...";
            GameObject.FindWithTag("Endgame").GetComponent<EndGame>().ShowResults();
        }
        Destroy(other.gameObject);
    }

    void DisplayRescueMsg(Vector3 position) {
        string msg = rescueMsgs[(int)Random.Range(0f, rescueMsgs.Length)];
        GameObject newMsg = Instantiate(rescueMsg, position, Quaternion.identity);
        newMsg.GetComponent<Text>().text = msg;
        newMsg.transform.SetParent(renderCanvas.transform, false);
        newMsg.tag = "Untagged";
    }
}
