using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    public GameObject psObj;
    private ParticleSystemRenderer psRenderer;

    private SpriteRenderer sr;
    private CircleCollider2D cc;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        cc = this.gameObject.GetComponent<CircleCollider2D>();
        psRenderer = psObj.GetComponent<ParticleSystemRenderer>();
        psRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
    }

    void CheckTouch() {
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos =  Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = new Vector3(touchPos.x, touchPos.y, 0f);
            
            if (touch.phase == TouchPhase.Ended) {
                Disable();
            } else if (touch.phase == TouchPhase.Began) {
                Enable();
            }
        }
    }

    void Enable() {
        cc.enabled = true;
        psRenderer.enabled = true;
    }

    void Disable() {
        cc.enabled = false;
        psRenderer.enabled = false;
    }
}
