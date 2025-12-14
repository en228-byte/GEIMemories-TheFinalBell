using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemoryTracker : MonoBehaviour
{
    //public DecayManager decayManager;
    public static int goodMemoriesFound = 0;
    public static int badMemoriesFound = 0;
    public static int lastSum = 0;
    public static int lastBad = 0;
    public static int lastGood = 0;
    public TMP_Text display;

    public void FindMemory(bool isGood)
    {
        if (isGood)
        {
            goodMemoriesFound++;
            //decayManager.ModifyDecay(-10);
            Debug.Log("Found a GOOD memory!");
        }
        else
        {
            badMemoriesFound++;
            //decayManager.ModifyDecay(15); 
            Debug.Log("Found a BAD memory! " + badMemoriesFound);
        }
    }

    private void Update()
    {
        display.text = "Good Memories: " + goodMemoriesFound + "\n Bad Memories: " + badMemoriesFound + "\n Last Bad: " + lastBad + "\n Last Good: " + lastGood;
    }

    public int GetGoodMemories() => goodMemoriesFound;
    public int GetBadMemories() => badMemoriesFound;
}
