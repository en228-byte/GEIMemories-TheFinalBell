using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private float speed = 3.5f;
    private int decayDecrease = 0;
    private Rigidbody2D rb;

    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = 0.0f;
        speed = speed - decayDecrease;

        //move forward (left to right)
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, 0.0f);

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);

        }
        //move backwards (right to left)
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, 0.0f);

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);

        }
        //move up (down to up)
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0.0f, speed);

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);

        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0.0f, -speed);

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);

        }
    }
}
