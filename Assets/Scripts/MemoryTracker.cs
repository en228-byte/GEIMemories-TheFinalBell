using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemoryTracker : MonoBehaviour
{
    public static int goodMemoriesFound = 0;
    public static int badMemoriesFound = 0;

    public static int lastSum = 0;
    public static int lastBad = 0;
    public static int lastGood = 0;

    [Header("UI")]
    public TMP_Text display;

    [Header("Ending Settings")]
    [Tooltip("Total number of memories required to end the game")]
    public int totalMemoriesToEndGame = 10;

    private bool endingTriggered = false;

    /// <summary>
    /// Call this whenever a memory is collected
    /// </summary>
    public void FindMemory(bool isGood)
    {
        Debug.Log("FindMemory CALLED"); // TEMP LOG

        if (isGood)
        {
            goodMemoriesFound++;
            Debug.Log("Found a GOOD memory!");
        }
        else
        {
            badMemoriesFound++;
            Debug.Log("Found a BAD memory! Total bad: " + badMemoriesFound);
        }

        CheckForEnding();
    }

    /// <summary>
    /// Checks whether enough memories have been collected to end the game
    /// </summary>
    void CheckForEnding()
    {
        if (endingTriggered)
            return;

        int total = goodMemoriesFound + badMemoriesFound;

        lastSum = total;
        lastGood = goodMemoriesFound;
        lastBad = badMemoriesFound;

        Debug.Log("Total memories collected: " + total);

        if (total >= totalMemoriesToEndGame)
        {
            endingTriggered = true;

            EndingController endingController = FindObjectOfType<EndingController>();

            if (endingController != null)
            {
                Debug.Log("Triggering ending via EndingController...");
                endingController.EvaluateEnding();
            }
            else
            {
                Debug.LogError("EndingController not found in scene!");
            }
        }
    }

    private void Update()
    {
        if (display != null)
        {
            display.text =
                "Good Memories: " + goodMemoriesFound +
                "\nBad Memories: " + badMemoriesFound +
                "\nLast Good: " + lastGood +
                "\nLast Bad: " + lastBad;
        }
    }

    public int GetGoodMemories() => goodMemoriesFound;
    public int GetBadMemories() => badMemoriesFound;
}
