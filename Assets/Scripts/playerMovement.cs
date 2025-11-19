using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float deltaX = 120;
    public float deltaY = 120;


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


            //move forward (left to right)
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(4.0f, 0.0f);
                
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = new Vector2(0.0f, 0.0f);
                
            }
            //move backwards (right to left)
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-4.0f, 0.0f);
                
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                rb.velocity = new Vector2(0.0f, 0.0f);
                
            }
            //move up (down to up)
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0.0f, 4.0f);
                
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                rb.velocity = new Vector2(0.0f, 0.0f);
                
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0.0f, -4.0f);
               
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = new Vector2(0.0f, 0.0f);
                
            }

        }
    /*
    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.name == "goodMemory1")
        {
            nextScene = "goodMemory1";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneChanging sceneChanger = new SceneChanging();
                sceneChanger.ChangeScene(nextScene);
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.name == "goodMemory2")
        {
            nextScene = "goodMemory2";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneChanging sceneChanger = new SceneChanging();
                sceneChanger.ChangeScene(nextScene);
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.name == "goodMemory3")
        {
            nextScene = "goodMemory3";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneChanging sceneChanger = new SceneChanging();
                sceneChanger.ChangeScene(nextScene);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == "badMemory1")
        {
            nextScene = "badMemory1";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneChanging sceneChanger = new SceneChanging();
                sceneChanger.ChangeScene(nextScene);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == "badMemory2")
        {
            nextScene = "badMemory2";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneChanging sceneChanger = new SceneChanging();
                sceneChanger.ChangeScene(nextScene);
                Destroy(collision.gameObject);
            }
        }
    }
    */

}
