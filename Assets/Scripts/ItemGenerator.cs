using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    private const float DISTANCE_TO_CHANGE = 20f;
    private const float DISTANCE_BETWEEN_ITEMS = 2f;
    private const float MIN_ITEMS = 10f;
    private const float MAX_ITEMS = 15f;

    // item probabilities
    private const float P_BOUNCE = 0.7f;
    private const float P_PERSON = 0.9f;
    private const float P_SLOW = 0.95f;

    private const float INITIAL_ASTEROID_PROB = 0.01f;
    private const float MAX_ASTEROID_PROB = 0.32f;
    private const float ASTEROID_PROB_INCREASE = 2f;

    // width of half the screen in units
    private float width;

    public GameObject[] items;
    public GameObject spaceman;
    public GameObject asteroid;

    private float probAsteroid;

    public float nextGenerationPos;

    // Start is called before the first frame update
    void Start()
    {    
        // calc width of screen in units
        width = ((float)Screen.width / Screen.height) * (Camera.main.orthographicSize);

        probAsteroid = INITIAL_ASTEROID_PROB;

        GenerateItems();
        UpdateLocation();
        nextGenerationPos = transform.position.y + DISTANCE_TO_CHANGE;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLocation();

        if (transform.position.y >= nextGenerationPos) {
            GenerateItems();
            nextGenerationPos += DISTANCE_TO_CHANGE;
        }

        CheckOutOfView(); 
    }

    // destroys game objects that are passed by the camera
    void CheckOutOfView() {
        GameObject[] gameObjs = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in gameObjs) {
            if (obj.transform.position.y < spaceman.transform.position.y - (Camera.main.orthographicSize * 3) ||
                obj.transform.position.x < transform.position.x - (width * 4) ||
                obj.transform.position.x > transform.position.x + (width * 4)) {
                Destroy(obj);
            }
        }
    }

    // updates item generator position in relation to Spaceman
    void UpdateLocation() {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, spaceman.transform.position.y + (DISTANCE_TO_CHANGE / 2f), 0f);
    }

    void GenerateItems() {
        int numItems = (int)(Random.Range(MIN_ITEMS, MAX_ITEMS + 1f));
        Vector3 pos = transform.position;
        float separation = DISTANCE_TO_CHANGE / numItems;
        for (int i = 0; i < numItems; i++) {
            GameObject item = GetRandomItem();
            if (item != null) {
                float itemY = pos.y + (separation * i);
                float itemX= Random.Range(pos.x - width, pos.x + width);
                Instantiate(item, new Vector3(itemX, itemY, 0f), Quaternion.identity);
            }
        }

        // generate asteroids 
        float chance = Random.Range(0f, 1f);
        if (chance < probAsteroid) {
            int numAsteroids = (int)Random.Range(1f, 3f);
            for (int i = 0; i < numAsteroids; i++) {
                float leftOrRight = Random.Range(0f, 1f);
                float xPos = leftOrRight < 0.5f ? transform.position.x - (width + 3f) : transform.position.x + (width + 3f);

                float yMin = transform.position.y - (Camera.main.orthographicSize * 3);
                float yMax = transform.position.y;
                float yPos = Random.Range(yMin, yMax);

                GameObject obj = Instantiate(asteroid, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                obj.SetActive(true);
            }
        }
        if (probAsteroid < MAX_ASTEROID_PROB) {
            probAsteroid *= ASTEROID_PROB_INCREASE;
        }
    }

    private GameObject GetRandomItem() {
        float num = Random.Range(0f, 1f);
        if (num < P_BOUNCE) {
            return items[0];
        } else if (num < P_PERSON) {
            return items[1];
        } else if (num < P_SLOW) {
            return items[2];
        }
        return null;
    }
}
