using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanging : MonoBehaviour
{
    static string lastScene;
    private void Start()
    {
        lastScene = "startScene";
    }
    public void ChangeScene(string sceneName)
    {
        //Scene scene = SceneManager.GetActiveScene();
        /*
        if (sceneName.Contains("Memory"))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            lastScene = sceneName;
            Debug.Log(lastScene);
        }
        if (sceneName.Contains("gamePlay"))
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.UnloadSceneAsync(lastScene);
        }
        */

        if (sceneName.Contains("Memory") || sceneName.Contains("minigame"))
        {
            //hide gameplay scene objects
            object[] items = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object item in items)
            {
                GameObject current = (GameObject) item;
                current.SetActive(false);
            }

            //load next scene
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        if (sceneName.Contains("gamePlay"))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "StartScene")
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                object[] items = GameObject.FindObjectsOfType(typeof(GameObject));
                foreach (object item in items)
                {
                    GameObject current = (GameObject)item;
                    current.SetActive(true);
                }
            }
        }
    }
}
