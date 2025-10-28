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
        Scene scene = SceneManager.GetActiveScene();
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
    }
}
