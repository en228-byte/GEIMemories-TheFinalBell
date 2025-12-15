using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class npcNoise : MonoBehaviour
{
    public AudioSource NPCSource;
    public AudioClip npc1;
    public AudioClip npc2;
    public AudioClip npc3;

    // Start is called before the first frame update
    void Start()
    {
        NPCSource.clip = npc1;
    }

    // Update is called once per frame
    void Update()
    {
        if (MemoryTracker.badMemoriesFound > 3)
        {
            NPCSource.clip = npc3;
        }
        else if (MemoryTracker.badMemoriesFound == 3)
        {
            NPCSource.clip = npc2;
        }
        else if (MemoryTracker.badMemoriesFound == 2)
        {
            NPCSource.clip = npc2;
        }
        else if (MemoryTracker.badMemoriesFound == 1)
        {
            NPCSource.clip = npc1;
        }
        else
        {
            NPCSource.clip = npc1;
        }
    }

    public void playNPC()
    {
        NPCSource.Play();
    }
}
