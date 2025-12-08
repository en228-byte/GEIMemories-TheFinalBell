using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hidePlay : MonoBehaviour
{
    void Start()
    {
       
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
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("hide"))
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.TryGetComponent<SpriteRenderer>(out var sr))
                    {
                        sr.enabled = false;
                    }
                    if (item.TryGetComponent<Collider2D>(out var col))
                    {
                        col.enabled = false;
                    }
                    if (item.TryGetComponent<UnityEngine.UI.Graphic>(out var ui))
                    {
                        ui.enabled = false;
                    }
                }
            } else
            {
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("hide"))
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (item.TryGetComponent<SpriteRenderer>(out var sr))
                    {
                        sr.enabled = true;
                    }

                    if (item.TryGetComponent<Collider2D>(out var col))
                    {
                        col.enabled = true;
                    }

                    if (item.TryGetComponent<UnityEngine.UI.Graphic>(out var ui))
                    {
                        ui.enabled = true;
                    }
                }
            }
        }
    }
}
