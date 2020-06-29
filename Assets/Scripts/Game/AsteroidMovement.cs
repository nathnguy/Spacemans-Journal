using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

    private const float SPEED = 2f;
    private const float DISTANCE_FROM_TARGET = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        GameObject spaceman = GameObject.FindWithTag("Spaceman");

        float distance = Random.Range(2f, DISTANCE_FROM_TARGET);

        float xDiff =  spaceman.transform.position.x - transform.position.x;
        float yDiff = (spaceman.transform.position.y + distance) - transform.position.y;
        float diffSpeed = Mathf.Sqrt(Mathf.Pow(xDiff, 2f) + Mathf.Pow(yDiff, 2f));

        float xVelocity = xDiff * (SPEED / diffSpeed);
        float yVelocity = yDiff * (SPEED / diffSpeed);
        rb.velocity = new Vector3(xVelocity, yVelocity, 0f);
    }
}
