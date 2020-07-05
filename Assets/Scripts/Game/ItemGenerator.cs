using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    private const float DISTANCE_TO_CHANGE = 20f;
    private const float MIN_ITEMS = 10f;
    private const float MAX_ITEMS = 14f;

    // item probabilities
    private const float P_BOUNCE = 0.7f;
    private const float P_PERSON = 0.9f;
    private const float P_SLOW = 0.95f;

    private const float CHIP_DISTANCE = 50f;

    private const float INITIAL_ASTEROID_PROB = 0f;
    private const float MAX_ASTEROID_PROB = 1f;
    private const float ASTEROID_PROB_INCREASE = 0.1f;

    // width of half the screen in units
    private float width;

    public GameObject[] items;
    public GameObject spaceman;
    public GameObject asteroid;

    private float probAsteroid;

    public float nextGenerationPos;

    private float startPos;

    // Start is called before the first frame update
    void Start()
    {    
        // calc width of screen in units
        width = ((float)Screen.width / Screen.height) * (Camera.main.orthographicSize);

        probAsteroid = INITIAL_ASTEROID_PROB;

        GenerateItems();
        UpdateLocation();
        nextGenerationPos = transform.position.y + DISTANCE_TO_CHANGE;

        startPos = transform.position.y;
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
            if (!obj.CompareTag("Audio") && !obj.CompareTag("DontDestroy") && !obj.CompareTag("GameData") &&
            obj.transform.position.y < spaceman.transform.position.y - (Camera.main.orthographicSize * 3) ||
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
        int numItems = (int)(UnityEngine.Random.Range(MIN_ITEMS, MAX_ITEMS + 1f));
        Vector3 pos = transform.position;
        float separation = DISTANCE_TO_CHANGE / numItems;
        for (int i = 0; i < numItems; i++) {
            GameObject item;

            // check if a chip should be placed
            GameData gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
            bool[] entriesFound = gameData.EntriesFound;
            bool[] entriesNotFound = Array.FindAll(entriesFound, entry => !entry);

            if (entriesNotFound.Length > 0 && (transform.position.y - startPos >= CHIP_DISTANCE) && i == 0) {
                item = items[3];
                startPos = transform.position.y;
            } else {
                item = GetRandomItem();
            }

            if (item != null) {
                float itemY = pos.y + (separation * i);
                float itemX= UnityEngine.Random.Range(pos.x - width, pos.x + width);
                Instantiate(item, new Vector3(itemX, itemY, 0f), Quaternion.identity);
            }
        }

        generateAsteroid();
    }

    private void generateAsteroid() {
        float chance = UnityEngine.Random.Range(0f, 1f);
        if (chance < probAsteroid) {
            int numAsteroids = (int)UnityEngine.Random.Range(1f, 3f);
            float yPos = transform.position.y;

            for (int i = 0; i < numAsteroids; i++) {
                float xPos = UnityEngine.Random.Range(-width, width);
                GameObject obj = Instantiate(asteroid, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                obj.SetActive(true);

                yPos += width;
            }
        }

        if (probAsteroid < MAX_ASTEROID_PROB) {
            probAsteroid += ASTEROID_PROB_INCREASE;
        }
    }

    private GameObject GetRandomItem() {
        float num = UnityEngine.Random.Range(0f, 1f);
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
