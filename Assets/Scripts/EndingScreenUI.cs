using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndingScreenUI : MonoBehaviour
{
    [SerializeField] UIDocument endingDocument;

    [Header("Scene Names")]
    [SerializeField] private string gameplaySceneName = "gamePlay";
    [SerializeField] private string mainMenuSceneName = "StartScene";

    private Button retryButton;
    private Button mainMenuButton;

    private void Awake()
    {
        if (endingDocument == null)
        {
            endingDocument = GetComponent<UIDocument>();
        }

        if (endingDocument == null)
        {
            Debug.LogError("EndingScreenUI: No UIDocument found!");
            return;
        }

        VisualElement root = endingDocument.rootVisualElement;

        retryButton = root.Q<Button>("RetryButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");

        // Register click callbacks
        if (retryButton != null)
        {
            retryButton.clicked += OnRetryClicked;
            Debug.Log("EndingScreenUI: RetryButton registered");
        }
        else
        {
            Debug.LogWarning("EndingScreenUI: RetryButton not found in UXML");
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.clicked += OnMainMenuClicked;
            Debug.Log("EndingScreenUI: MainMenuButton registered");
        }
        else
        {
            Debug.LogWarning("EndingScreenUI: MainMenuButton not found in UXML");
        }
    }

    private void OnDestroy()
    {
        // Unregister callbacks to prevent memory leaks
        if (retryButton != null)
            retryButton.clicked -= OnRetryClicked;

        if (mainMenuButton != null)
            mainMenuButton.clicked -= OnMainMenuClicked;
    }

    private void OnRetryClicked()
    {
        Debug.Log("Retry button clicked - Restarting game");

        // Reset game state for fresh playthrough
        GameState.ResetGameState();

        // Load gameplay scene directly (skip intro since player has seen it)
        SceneManager.LoadScene(gameplaySceneName);
    }

    private void OnMainMenuClicked()
    {
        Debug.Log("Main Menu button clicked - Returning to main menu");

        // Reset game state when going to main menu
        GameState.ResetGameState();

        SceneManager.LoadScene(mainMenuSceneName);
    }
}
