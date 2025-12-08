using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class memoryInteraction : MonoBehaviour
{
    public string nextScene;
    public GameObject memory;
    GameObject goodMemory1;
    GameObject goodMemory2;
    GameObject goodMemory3;
    GameObject goodMemory4;
    GameObject goodMemory5;
    GameObject badMemory1;
    GameObject badMemory2;
    GameObject badMemory3;
    GameObject badMemory4;
    GameObject badMemory5;
    public static GameObject[] memories;


    private void Start()
    {
        memories = new GameObject[] { goodMemory1, goodMemory2, goodMemory3, goodMemory4, goodMemory5, badMemory1, badMemory2, badMemory3, badMemory4, badMemory5 };
        for (int i = 0; i < memories.Length; i++)
        {
            memories[i] = Instantiate(memory);
            //memories[i].tag = "hide";
            if (i < 5)
            {
                memories[i].name = "goodMemory" + (i + 1);
            } else
            {
                memories[i].name = "badMemory" + (i - 4);
            }
        }
        memories[0].transform.position = new Vector3(-13.75f, 1f, 0f);
        memories[1].transform.position = new Vector3(3.25f, 5.75f, 0f);
        memories[2].transform.position = new Vector3(17f, 0f, 0f);
        memories[3].transform.position = new Vector3(10.84f, 6f, 0f);
        memories[4].transform.position = new Vector3(-12f, 7f, 0f);
        memories[5].transform.position = new Vector3(1.65f, 4f, 0f);
        memories[6].transform.position = new Vector3(13.6f, 7.5f, 0f);
        memories[7].transform.position = new Vector3(-13.87f, 0.41f, 0f);
        memories[8].transform.position = new Vector3(-4.5f, 1.82f, 0f);
        memories[9].transform.position = new Vector3(0f, 7.5f, 0f);
    }

    public void Update()
    {
        
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        for (int i = 0; i < memories.Length; i++)
        {
            if (collision.gameObject.ToString() == memories[i].ToString())
            {
                nextScene = collision.gameObject.name;
                if (Input.GetKey(KeyCode.E))
                {
                    SceneChanging sceneChanger = new SceneChanging();
                    sceneChanger.ChangeScene(nextScene);
                    collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }

    public static void hideOutside(string newBackground)
    {
        for (int i = 0; i < memories.Length; i++)
        {
            try
            {
                memories[i].SetActive(true);
                if (newBackground == "lr")
                {
                    memories[i].SetActive(false);
                }
                if (newBackground == "td")
                {
                    memories[i].SetActive(false);
                }
                if (newBackground == "cl")
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    if (i == 5)
                    {
                        continue;
                    }
                    memories[i].SetActive(false);
                }
                if (newBackground == "ca")
                {
                    if (i == 2)
                    {
                        continue;
                    }
                    if (i == 7)
                    {
                        continue;
                    }
                    memories[i].SetActive(false);
                }
                if (newBackground == "p")
                {
                    if (i == 4)
                    {
                        continue;
                    }
                    if (i == 9)
                    {
                        continue;
                    }
                    memories[i].SetActive(false);
                }
                if (newBackground == "l")
                {
                    if (i == 3)
                    {
                        continue;
                    }
                    if (i == 8)
                    {
                        continue;
                    }
                    memories[i].SetActive(false);
                }
                if (newBackground == "g")
                {
                    if (i == 1)
                    {
                        continue;
                    }
                    if (i == 6)
                    {
                        continue;
                    }
                    memories[i].SetActive(false);
                }
            }
            catch (MissingReferenceException)
            {
                continue;
            }
        }
    }
}
