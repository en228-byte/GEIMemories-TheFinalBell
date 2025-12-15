using UnityEngine;

/// <summary>
/// Static utility class for managing game state across scenes.
/// Handles resetting all game progress when starting a new game or retrying.
/// </summary>
public static class GameState
{
    /// <summary>
    /// Resets all game state to initial values.
    /// Call this when starting a new game or retrying from an ending.
    /// </summary>
    public static void ResetGameState()
    {
        Debug.Log("GameState: Resetting all game state...");

        // Reset MemoryTracker if it exists (will be available after merge with decay branch)
        ResetMemoryTracker();

        // Reset DecayManager if it exists
        ResetDecayManager();

        // Reset navigation gates if they exist
        ResetNavigationGates();

        Debug.Log("GameState: Reset complete");
    }

    private static void ResetMemoryTracker()
    {
        // Using reflection-style check to work before/after merge
        var memoryTrackerType = System.Type.GetType("MemoryTracker");
        if (memoryTrackerType != null)
        {
            // Reset static fields
            var goodField = memoryTrackerType.GetField("goodMemoriesFound", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var badField = memoryTrackerType.GetField("badMemoriesFound", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var lastSumField = memoryTrackerType.GetField("lastSum", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var lastBadField = memoryTrackerType.GetField("lastBad", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var lastGoodField = memoryTrackerType.GetField("lastGood", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            if (goodField != null) goodField.SetValue(null, 0);
            if (badField != null) badField.SetValue(null, 0);
            if (lastSumField != null) lastSumField.SetValue(null, 0);
            if (lastBadField != null) lastBadField.SetValue(null, 0);
            if (lastGoodField != null) lastGoodField.SetValue(null, 0);

            Debug.Log("GameState: MemoryTracker reset");
        }
    }

    private static void ResetDecayManager()
    {
        var decayManagerType = System.Type.GetType("DecayManager");
        if (decayManagerType != null)
        {
            var decayLevelField = decayManagerType.GetField("decayLevel", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            if (decayLevelField != null)
            {
                decayLevelField.SetValue(null, 0f);
                Debug.Log("GameState: DecayManager reset");
            }
        }
    }

    private static void ResetNavigationGates()
    {
        var navigationType = System.Type.GetType("navigation");
        if (navigationType != null)
        {
            // Reset gate states
            var gate1 = navigationType.GetField("gate1", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var gate2 = navigationType.GetField("gate2", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var gate3 = navigationType.GetField("gate3", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var gate4 = navigationType.GetField("gate4", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var exitGate = navigationType.GetField("exitGate", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            if (gate1 != null) gate1.SetValue(null, "lo");
            if (gate2 != null) gate2.SetValue(null, "lo");
            if (gate3 != null) gate3.SetValue(null, "lo");
            if (gate4 != null) gate4.SetValue(null, "lo");
            if (exitGate != null) exitGate.SetValue(null, "lo");

            Debug.Log("GameState: Navigation gates reset");
        }
    }
}
