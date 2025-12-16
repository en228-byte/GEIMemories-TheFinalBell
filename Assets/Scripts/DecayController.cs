using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayController : MonoBehaviour
{
    public DecayBarUI decayBarUI;

    void Start()
    {
        if (decayBarUI != null)
        {
            decayBarUI.SetMax(5);
            UpdateDecay();
        }
    }

    void Update()
    {
        UpdateDecay();
    }

    void UpdateDecay()
    {
        if (decayBarUI != null)
        {
            decayBarUI.SetValue(MemoryTracker.badMemoriesFound);
        }
    }
}