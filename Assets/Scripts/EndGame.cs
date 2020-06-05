using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    private const float CUSHION = 1.5f;


    public GameObject resultsScreen;
    public GameObject score;
    public GameObject rescued;

    private GameObject spaceman;
    private float screenHeight;
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        spaceman = GameObject.FindWithTag("Spaceman");
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = ((float)Screen.width / Screen.height) * screenHeight;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOutOfBounds();
    }

    void CheckOutOfBounds() {
        Vector3 manPos = spaceman.transform.position;
        Vector3 middleCamPos = transform.position;
        float boundLeft = middleCamPos.x - (screenWidth / 2f) - CUSHION;
        float boundRight = middleCamPos.x + (screenWidth / 2f) + CUSHION;
        float boundBottom = middleCamPos.y - (screenHeight / 2f) - CUSHION;

        float xPos = manPos.x;
        float yPos = manPos.y;

        if (xPos < boundLeft || xPos > boundRight || yPos < boundBottom) {
            ShowResults();
        }
    }

    public void ShowResults() {
        spaceman.SetActive(false);
        score.SetActive(false);
        rescued.GetComponent<Text>().text = score.GetComponent<Text>().text;

        resultsScreen.SetActive(true);
    }
}