using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float deltaX = 0.1f;
    public float deltaY = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //move forward (left to right)
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = new Vector3(deltaX/10, 0, 0);
            transform.Translate ( movement);
        }
        //move backwards (right to left)
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(-deltaX/10, 0, 0);
            transform.Translate(movement);
        }
        //move up (down to up)
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 movement = new Vector3(0, deltaY/10, 0);
            transform.Translate(movement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 movement = new Vector3(0, -deltaY/10, 0);
            transform.Translate(movement);
        }

    }
}
