using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DecayManager : MonoBehaviour
{
    [Range(0, 100)] public float decayLevel = 0f;
    public UnityEvent<float> onDecayChanged; 

    public void ModifyDecay(float amount)
    {
        decayLevel = Mathf.Clamp(decayLevel + amount, 0, 100);

        Debug.Log("Decay now at: " + decayLevel);

        if (onDecayChanged != null)
            onDecayChanged.Invoke(decayLevel);

        CheckEndConditions();
    }

    private void CheckEndConditions()
    {
        if (decayLevel >= 80)
        {
            Debug.Log("DECAY ENDING APPROACHING...");
        }
        else if (decayLevel <= 20)
        {
            Debug.Log("Good mental state maintained.");
        }
    }
}

