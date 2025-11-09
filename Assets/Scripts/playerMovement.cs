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
    public GameObject memory;
    GameObject goodMemory1;
    GameObject goodMemory2;
    GameObject goodMemory3;
    GameObject badMemory1;
    GameObject badMemory2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        goodMemory1 = Instantiate(memory);
        goodMemory1.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
        goodMemory1.name = "goodMemory1";

        badMemory1 = Instantiate(memory);
        badMemory1.transform.position = new Vector3(6.0f, 5.0f, 0.0f);
        badMemory1.name = "badMemory1";

        goodMemory2 = Instantiate(memory);
        goodMemory2.transform.position = new Vector3(0.5f, 4.75f, 0.0f);
        goodMemory2.name = "goodMemory2";
        goodMemory2.SetActive(false);

        badMemory2 = Instantiate(memory);
        badMemory2.transform.position = new Vector3(6.0f, -7.0f, 0.0f);
        badMemory2.name = "badMemory2";
        badMemory2.SetActive(false);

        goodMemory3 = Instantiate(memory);
        goodMemory3.transform.position = new Vector3(0.5f, 7.76f, 0.0f);
        goodMemory3.name = "goodMemory3";
        goodMemory3.SetActive(false);
        GameObject[] memories = { goodMemory1, badMemory1, goodMemory2, badMemory2, goodMemory3 };

    }

    // Update is called once per frame
    void Update()
    {


        //move forward (left to right)
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(3.0f, 0.0f);
            
        }
        else if (Input.GetKeyUp(KeyCode.D)) {
            rb.velocity = new Vector2(0.0f, 0.0f);
            
        }
        //move backwards (right to left)
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-3.0f, 0.0f);
            
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            
        }
        //move up (down to up)
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0.0f, 3.0f);
            
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0.0f, -3.0f);
            
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            
        }

    }

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
                goodMemory2.SetActive(true);
                badMemory2.SetActive(true);
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
                goodMemory3.SetActive(true);
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
    public static GameObject Get(GameObject obj)
    {
        return obj;
    }
}
