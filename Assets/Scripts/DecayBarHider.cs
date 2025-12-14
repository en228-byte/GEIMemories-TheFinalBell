using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class DecayBarHider : MonoBehaviour
{
    public GameObject decayBar;

    void Update()
    {
        bool shouldHide = false;

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene s = SceneManager.GetSceneAt(i);
            if (!s.isLoaded) continue;

            string name = s.name;

            if (name.IndexOf("minigame", StringComparison.OrdinalIgnoreCase) >= 0 ||
                name.IndexOf("Memory", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                shouldHide = true;
                break;
            }
        }

        if (decayBar != null && decayBar.activeSelf == shouldHide)
        {
            decayBar.SetActive(!shouldHide);
        }
    }
}