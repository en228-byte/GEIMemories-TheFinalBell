using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    [Header("Ending Scene Names")]
    public string goodEndingScene = "EndScene_Good";
    public string neutralEndingScene = "EndScene_Neutral";
    public string badEndingScene = "EndScene_Bad";

    public void PlayEnding()
    {
        int good = MemoryTracker.goodMemoriesFound;
        int bad = MemoryTracker.badMemoriesFound;

        Debug.Log($"Ending Check → Good: {good}, Bad: {bad}");

        if (good > bad)
        {
            SceneManager.LoadScene(goodEndingScene);
        }
        else if (bad > good)
        {
            SceneManager.LoadScene(badEndingScene);
        }
        else
        {
            SceneManager.LoadScene(neutralEndingScene);
        }
    }
}
