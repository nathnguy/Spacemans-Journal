using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private Vector3 CLOCKWISE = new Vector3(0f, 0f , -1f);
    private Vector3 COUNTER_CLOCKWISE = new Vector3(0f, 0f, 1f);
    private Vector3 rotation;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] rotations = {CLOCKWISE, COUNTER_CLOCKWISE};
        rotation = rotations[(int)Random.Range(0f, rotations.Length)];

        Sprite personSprite = sprites[(int)Random.Range(0f, sprites.Length)];
        GetComponent<SpriteRenderer>().sprite = personSprite;
    }

    void FixedUpdate() {
        transform.Rotate(rotation);
    }
}
