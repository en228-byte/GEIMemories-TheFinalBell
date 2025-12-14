using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;

    public TMP_Text timerText;
    public GameController gameController;

    private bool timerRunning = true;

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("TimerText is NOT assigned!");
            enabled = false;
            return;
        }

        currentTime = startTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (!timerRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerRunning = false;
            TimeUp();
        }

        UpdateTimerUI();
    }

    void TimeUp()
    {
        gameController.PlayerWon();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
