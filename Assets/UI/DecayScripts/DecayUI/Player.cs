using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the player's health and updates the decay/health bar
public class Player : MonoBehaviour
{
    // The maximum amount of health the player can have
    public int maxHealth = 100;
    public int currentHealth;

    // Reference to the decaybar (health bar) UI script
    public decaybar healthBar;  

    // Called once when the game starts
    void Start()
    {
        // Set the player's current health to full
        currentHealth = maxHealth;
        // Initialize the health bar to match the maximum health
        healthBar.SetMaxHealth(maxHealth);
    }

    // Called once per frame
    void Update()
    {
        // Check if the Space key was pressed this frame
        // (used here to test taking damage)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reduce the player's health by 20
            TakeDamage(20);
        }
    }

    // Reduces the player's health and updates the health bar
    void TakeDamage(int damage)
    {
        // Subtract damage from the current health
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}