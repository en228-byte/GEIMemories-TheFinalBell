using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hidePlay : MonoBehaviour
{
    object[] items;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        items = GameObject.FindGameObjectsWithTag("hide");
        //goes through all active scenes
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var temp = SceneManager.GetSceneAt(i);
            //if any memory or minigame is active
            if (temp.name.Contains("Memory") || temp.name.Contains("minigame"))
            {
                //cycle through all objects in gamePlay scene
                foreach (object item in items)
                {
                    GameObject current = (GameObject)item;
                    //makes them invisible if not camera
                    current.SetActive(false);
                }
            } else
            {
                foreach (object item in items)
                {
                    //makes them visible
                    GameObject current = (GameObject)item;
                    current.SetActive(true);
                }
            }
        }
    }
}
