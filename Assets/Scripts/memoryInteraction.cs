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
        //good memories
        memories[0].transform.position = new Vector3(-13.75f, 1f, 0f);

        memories[1].transform.position = new Vector3(3.25f, 5.75f, 0f);
        memories[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        memories[2].transform.position = new Vector3(16.45f, 0.96f, 0f);
        memories[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        memories[3].transform.position = new Vector3(13.25f, -5.01f, 0f);
        memories[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        memories[4].transform.position = new Vector3(-15.64f, 1.86f, 0f);

        //bad memories
        memories[5].transform.position = new Vector3(13.62f, 8.32f, 0f);
        memories[5].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        memories[6].transform.position = new Vector3(13.6f, 7.5f, 0f);

        memories[7].transform.position = new Vector3(-13.36f, 1.85f, 0f);
        memories[7].transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        memories[8].transform.position = new Vector3(-4.47f, 1.68f, 0f);
        memories[8].transform.localScale = new Vector3(0.075f, 0.075f, 0.075f);

        memories[9].transform.position = new Vector3(0f, 7.23f, 0f);
        memories[9].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
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


                    MemoryTracker track = new MemoryTracker();
                    if (collision.gameObject.ToString().Contains("good"))
                    {
                        track.FindMemory(true);
                    } else if (collision.gameObject.ToString().Contains("bad"))
                    {
                        track.FindMemory(false);
                    }
                    
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
                if (newBackground == "sp1")
                {
                    memories[i].SetActive(false);
                }
                if (newBackground == "sp2")
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
