using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{

    private const float BACKGROUND_HEIGHT = 11.49f;

    public GameObject background;

    private GameObject spaceman;
    private float distanceFromSpaceman;

    private float nextGenPos;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(background, transform.position, Quaternion.identity);
        spaceman = GameObject.FindWithTag("Spaceman");
        distanceFromSpaceman = transform.position.y - spaceman.transform.position.y;
        nextGenPos = transform.position.y + BACKGROUND_HEIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        GenerateBackground();
    }

    void UpdatePosition() {
        transform.position = new Vector3(0f, spaceman.transform.position.y + distanceFromSpaceman, 0f);
    }

    void GenerateBackground() {
        if (transform.position.y >= nextGenPos) {
            Instantiate(background, new Vector3(0f, nextGenPos, 0f), Quaternion.identity);
            nextGenPos += BACKGROUND_HEIGHT;
        }
    }


}
