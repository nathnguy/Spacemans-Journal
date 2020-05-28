﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{

    public GameObject st;
    private ScoreTracker increaseRescued;
    private SpacemanMovement sm;

    // Start is called before the first frame update
    void Start()
    {
        increaseRescued = st.GetComponent<ScoreTracker>();
        sm = GetComponent<SpacemanMovement>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Person")) {
            increaseRescued.IncreaseRescued();
        } else if (other.CompareTag("Slow")) {
            sm.SpeedDebuff();
        }
        Destroy(other.gameObject);
    }
}