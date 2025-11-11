using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hidePlay : MonoBehaviour
{
    //object[] items;
    //object[] makeInvisible;
    // Start is called before the first frame update
    void Start()
    {
        /*
        items = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (object item in items)
        {
            GameObject current = (GameObject)item;
            //makes them invisible if not camera
            if (!current.CompareTag("MainCamera") && !current.CompareTag("ignore"))
            {
                current.tag = "hide";
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //makeInvisible = GameObject.FindGameObjectsWithTag("hide");
        //goes through all active scenes
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var temp = SceneManager.GetSceneAt(i);
            //if any memory or minigame is active
            if (temp.name.Contains("Memory") || temp.name.Contains("Minigame"))
            {
                //cycle through all objects in gamePlay scene
                foreach (object item in GameObject.FindGameObjectsWithTag("hide"))
                {
                    GameObject current = (GameObject)item;
                    //makes them invisible if not camera
                    try
                    {
                        current.GetComponent<SpriteRenderer>().enabled = false;
                        try
                        {
                            current.GetComponent<Collider2D>().enabled = false;
                        }
                        catch
                        {
                            break;
                        }
                        Debug.Log(current.name + "invisible");
                    }
                    catch
                    {
                        break;
                    }
                    
                }
            } else
            {
                Debug.Log("hide Test 1");
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("hide"))
                {
                    //makes them visible
                    GameObject current = item;
                    try
                    {
                        current.GetComponent<SpriteRenderer>().enabled = true;
                        try
                        {
                            current.GetComponent<Collider2D>().enabled = true;
                        }
                        catch
                        {
                            break;
                        }
                        Debug.Log(current.name + "visible");
                    }
                    catch
                    {
                        break;
                    }
                }
            }
        }
    }
}
