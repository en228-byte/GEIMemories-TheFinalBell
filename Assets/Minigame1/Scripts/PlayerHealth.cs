using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public UnityEvent onPlayerDeath;
    public HeartsUI heartsUI;

    int lives;

    void Start()
    {
        lives = maxLives;
        heartsUI?.SetLives(lives, maxLives);
    }

    public void TakeHit(int amount = 1)
    {
        if (lives <= 0) return;
        lives -= amount;
        heartsUI?.SetLives(lives, maxLives);
        if (lives <= 0) onPlayerDeath?.Invoke();
    }

    public void ResetLives()
    {
        lives = maxLives;
        heartsUI?.SetLives(lives, maxLives);
    }
}
