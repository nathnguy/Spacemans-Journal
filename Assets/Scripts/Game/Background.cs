using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        Sprite backgroundImg = sprites[(int)Random.Range(0f, sprites.Length)];
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = backgroundImg;
    }   
}
