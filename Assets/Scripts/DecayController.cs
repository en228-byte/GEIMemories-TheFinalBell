using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayController : MonoBehaviour
{
    public DecayBarUI decayBarUI;

    void Start()
    {
        decayBarUI.SetMax(5);
        UpdateDecay();
    }

    void Update()
    {
        UpdateDecay();
    }

    void UpdateDecay()
    {
        decayBarUI.SetValue(MemoryTracker.badMemoriesFound);
    }
}