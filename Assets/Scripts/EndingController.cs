using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    [Header("Scene Names")]
    public string goodEndingScene = "EndScene_Good";
    public string neutralEndingScene = "EndScene_Neutral";
    public string badEndingScene = "EndScene_Bad";

    [Header("Thresholds")]
    public int goodMemoryThreshold = 3;
    public int badMemoryThreshold = 3;
    public float highDecayThreshold = 75f;

    private bool endingTriggered = false;

    /// <summary>
    /// Evaluates which ending should be triggered based on good/bad memories and decay.
    /// </summary>
    public void EvaluateEnding()
    {
        if (endingTriggered)
            return;

        int good = MemoryTracker.goodMemoriesFound;
        int bad = MemoryTracker.badMemoriesFound;
        float decay = DecayManager.decayLevel;

        endingTriggered = true;

        Debug.Log($"Evaluating Ending: Good={good}, Bad={bad}, Decay={decay}");

        // Use SceneChanging singleton if available, otherwise fallback to SceneManager
        if (SceneChanging.Instance != null)
        {
            if (decay >= highDecayThreshold || bad >= badMemoryThreshold)
            {
                Debug.Log("Triggering BAD ending");
                SceneChanging.Instance.ChangeScene(badEndingScene);
            }
            else if (good >= goodMemoryThreshold && decay < highDecayThreshold)
            {
                Debug.Log("Triggering GOOD ending");
                SceneChanging.Instance.ChangeScene(goodEndingScene);
            }
            else
            {
                Debug.Log("Triggering NEUTRAL ending");
                SceneChanging.Instance.ChangeScene(neutralEndingScene);
            }
        }
        else
        {
            Debug.LogWarning("SceneChanging singleton not found. Using SceneManager.LoadScene instead.");

            if (decay >= highDecayThreshold || bad >= badMemoryThreshold)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(badEndingScene);
            }
            else if (good >= goodMemoryThreshold && decay < highDecayThreshold)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(goodEndingScene);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(neutralEndingScene);
            }
        }
    }
}
