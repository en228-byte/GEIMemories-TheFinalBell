using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        AudioListener.pause = false; // pause audio
        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true; // unpause audio
    }

    public void Retry()
    {
    AudioListener.pause = false;
    Time.timeScale = 1f;
    SceneManager.LoadScene("minigame1");
    }
}
