using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryTracker : MonoBehaviour
{
    public DecayManager decayManager;
    private int goodMemoriesFound = 0;
    private int badMemoriesFound = 0;

    public void FindMemory(bool isGood)
    {
        if (isGood)
        {
            goodMemoriesFound++;
            decayManager.ModifyDecay(-10);
            Debug.Log("Found a GOOD memory!");
        }
        else
        {
            badMemoriesFound++;
            decayManager.ModifyDecay(15); 
            Debug.Log("Found a BAD memory!");
        }
    }

    public int GetGoodMemories() => goodMemoriesFound;
    public int GetBadMemories() => badMemoriesFound;
}