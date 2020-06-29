using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteRotation : MonoBehaviour
{
    private const float MAX_ROTATION = 1f;
    private Vector3 rotation;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        float rotationAmount = Random.Range(0.5f, MAX_ROTATION);
        rotationAmount *= RandomNegative();
        rotation = new Vector3(0f, 0f, rotationAmount);

        if (sprites.Length > 0) {
            Sprite personSprite = sprites[(int)Random.Range(0f, sprites.Length)];
            GetComponent<SpriteRenderer>().sprite = personSprite;
        }
    }

    void FixedUpdate() {
        transform.Rotate(rotation);
    }

    float RandomNegative() {
        float result = Random.Range(-1f, 1f) < 0f ? -1f : 1f; 
        return result;
    }
}
