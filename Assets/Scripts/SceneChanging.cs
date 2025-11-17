using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanging : MonoBehaviour
{
    string cur;
    static string lastScene;
    private void Start()
    {
        lastScene = "startScene";
    }

    private void Update()
    {
        if (cur != null)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var temp = SceneManager.GetSceneAt(i);
                if (temp.name == cur)
                {
                    SceneManager.SetActiveScene(temp);
                    Debug.Log(SceneManager.GetActiveScene().name);
                }
            }
        }
        
    }
    public void ChangeScene(string sceneName)
    {
        

        if (sceneName.Contains("Memory") || sceneName.Contains("minigame"))
        {
            lastScene = sceneName;
            //load next scene
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var temp = SceneManager.GetSceneAt(i);
                if (temp.name == sceneName)
                {
                    return;
                }
            }
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
                SceneManager.UnloadSceneAsync(lastScene);
            }
        }
        cur = sceneName;
    }
}
