using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PendulumScript : MonoBehaviour
{
    public float speed = 3.0f;
    public float limit = 75f;

    public bool randomStart = false;
    private float random = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (randomStart)
        {
            random = UnityEngine.Random.Range(0f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time + random);
        transform.localRotation = Quaternion.Euler(0, 0,angle);
    }
}