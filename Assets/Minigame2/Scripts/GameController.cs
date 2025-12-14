using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool GameStarted = false;

    [SerializeField] private PlayerController playerController;

    public Canvas GameOverCanvas;
    public Canvas WinCanvas;
    public Canvas TutorialCanvas;

    private bool isGameOver = false;

    private void Awake()
    {
        if (playerController != null)
        {
            playerController.PlayerDied += WhenPlayerDies;
        }

        GameOverCanvas.gameObject.SetActive(false);
        WinCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        GameStarted = false;
        Time.timeScale = 0f;
        TutorialCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!GameStarted && Input.anyKeyDown)
        {
            StartGame();
        }

        if (isGameOver && Input.anyKeyDown)
        {
            RetryClicked();
        }
    }

    void WhenPlayerDies()
    {
        isGameOver = true;
        GameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;

        if (playerController != null)
        {
            playerController.PlayerDied -= WhenPlayerDies;
        }
    }

    public void PlayerWon()
    {
        WinCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        GameStarted = true;
        TutorialCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RetryClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
