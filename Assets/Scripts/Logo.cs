using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{

    private const float MAX_ROTATION = 2f;
    private const float MAX_SPEED = 1f;
    private const int WAIT_TIME = 5;

    private Vector3 rotation;
    private Rigidbody2D rb;

    void Start() {
        rotation = new Vector3();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FlyAway());
    }

    void FixedUpdate()
    {
        transform.Rotate(rotation);
    }

    IEnumerator FlyAway() {
        yield return new WaitForSeconds(WAIT_TIME);
        
        float rotationSpeed = Random.Range(-MAX_ROTATION, MAX_ROTATION);
        rotation = new Vector3(0f, 0f, rotationSpeed);

        float xVel = Random.Range(-MAX_SPEED, MAX_SPEED);
        float yVel = Random.Range(-MAX_SPEED, MAX_SPEED);
        rb.velocity = new Vector3(xVel, yVel, 0f);
    }

    void OnCollisionEnter2D(Collision2D other) {
        rotation *= -1f;
        if (other.gameObject.CompareTag("BoundSide")) {
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0f);
        } else {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0f);
        }
    }
}
