using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    [Header("Falling Object")]
    public GameObject fallingObject;

    [Header("Spawn Area")]
    public float spawnXRange = 12f;
    public float spawnY = 10f;

    [Header("Spawn Rate")]
    public float startDelay = 0.2f;
    public float minDelay = 0.1f;
    public float difficultyRamp = 0.02f;

    [Header("Spawn Count")]
    public int startSpawnCount = 4;
    public int maxSpawnCount = 10;

    [Header("Anti-Camping")]
    public Transform player;
    public float playerBiasChance = 0.35f;
    public float playerBiasRange = 2.5f;

    private float currentDelay;
    private int currentSpawnCount;

    void Start()
    {
        currentDelay = startDelay;
        currentSpawnCount = startSpawnCount;

        InvokeRepeating(nameof(Fall), 0f, currentDelay);
        InvokeRepeating(nameof(IncreaseDifficulty), 4f, 3f);
    }

    void IncreaseDifficulty()
    {
        // Speed up spawns
        currentDelay = Mathf.Max(minDelay, currentDelay - difficultyRamp);

        // Increase knives per wave
        if (currentSpawnCount < maxSpawnCount)
            currentSpawnCount++;

        CancelInvoke(nameof(Fall));
        InvokeRepeating(nameof(Fall), 0f, currentDelay);
    }

    void Fall()
    {
        for (int i = 0; i < currentSpawnCount; i++)
        {
            float spawnX;

            if (player != null && Random.value < playerBiasChance)
            {
                spawnX = player.position.x + Random.Range(-playerBiasRange, playerBiasRange);
            }
            else
            {
                spawnX = Random.Range(-spawnXRange, spawnXRange);
            }

            Instantiate(
                fallingObject,
                new Vector3(spawnX, spawnY, 0f),
                Quaternion.identity
            );
        }
    }
}
