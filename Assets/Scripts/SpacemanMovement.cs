using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacemanMovement : MonoBehaviour
{
    
    private const float INITIAL_SPEED = 1f;
    private const float SPEED_INCREASE = 0.02f;
    private const float SPEED_DEBUFF = 0.2f;

    private Vector3 CLOCKWISE = new Vector3(0f, 0f, -2f);
    private Vector3 COUNTER_CLOCKWISE = new Vector3(0f, 0f, 2f);
    
    // for changing velocity
    public Rigidbody2D rb;
    private float xVelocity;
    private float yVelocity;

    private Vector3 rotation;

    // increases when collision occurs
    public float speedMultiplier;

    private Animator animation;

    // sound
    private AudioManager am;
    

    // Start is called before the first frame update
    void Start()
    {
        yVelocity = INITIAL_SPEED;
        speedMultiplier = 1f;

        rotation = CLOCKWISE;
        am = FindObjectOfType<AudioManager>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float animationSpeed = speedMultiplier > 2f ? 2f : speedMultiplier;
        animation.SetFloat("speedMultiplier", animationSpeed);
    }

    void FixedUpdate() {
        transform.Rotate(rotation);
        UpdateSpeed();
    }

    // increases speedMultiplier and changes velocity to the vector perpendicular
    // to the tangent line of the point of collision
    void OnCollisionEnter2D(Collision2D collision) {
        am.Play("Bounce");
        ContactPoint2D contact = collision.contacts[0];

        // make sure velocity always has same magnitude
        float xDiff = transform.position.x - contact.point.x;
        float yDiff = transform.position.y - contact.point.y;
        float diffSpeed = Mathf.Sqrt(Mathf.Pow(xDiff, 2f) + Mathf.Pow(yDiff, 2f));

        // scalar multiple for velocity vector
        float factor = INITIAL_SPEED / diffSpeed;

        xVelocity = xDiff * factor;
        yVelocity = yDiff * factor;

        UpdateSpeed();

        // increase speed for each collision
        speedMultiplier += SPEED_INCREASE;

        CheckRotation(contact.point);
    }

    // rotates based on transform position relative to point position
    void CheckRotation(Vector2 point) {
        Vector3 pos = transform.position;
        if ((point.y > pos.y && point.x > pos.x) || (point.y < pos.y && point.x < pos.x)) {
            rotation = CLOCKWISE;
        } else {
            rotation = COUNTER_CLOCKWISE;
        }
    }

    // for slowing down
    public void SpeedDebuff() {
        speedMultiplier -= SPEED_DEBUFF;
        CheckSpeed();
        UpdateSpeed();
    }

    // updates velocity with speed multiplier
    void UpdateSpeed() {
        rb.velocity = new Vector3(xVelocity * speedMultiplier, yVelocity * speedMultiplier, 0f);
    }

    // speed multiplier cannot be lower than 1
    void CheckSpeed() {
        if (speedMultiplier < 1f) {
            speedMultiplier = 1f;
        }
    }
}
