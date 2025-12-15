using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UIDocument mainMenuDocument;

    [Header("Scene Names")]
    [SerializeField] private string gameplaySceneName = "gamePlay";

    private Button startButton;
    private Button continueButton;
    private Button exitButton;

    private void Awake()
    {
        VisualElement root = mainMenuDocument.rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        continueButton = root.Q<Button>("ContinueButton");
        exitButton = root.Q<Button>("ExitButton");

        // Register click callbacks
        if (startButton != null)
        {
            startButton.clicked += OnStartClicked;
        }

        if (continueButton != null)
        {
            continueButton.clicked += OnContinueClicked;
        }

        if (exitButton != null)
        {
            exitButton.clicked += OnExitClicked;
        }
    }

    private void OnDestroy()
    {
        // Unregister callbacks to prevent memory leaks
        if (startButton != null)
            startButton.clicked -= OnStartClicked;

        if (continueButton != null)
            continueButton.clicked -= OnContinueClicked;

        if (exitButton != null)
            exitButton.clicked -= OnExitClicked;
    }

    private void OnStartClicked()
    {
        Debug.Log("Start button clicked - Loading gameplay scene");

        // Reset game state when starting new game
        GameState.ResetGameState();

        SceneManager.LoadScene(gameplaySceneName);
    }

    private void OnContinueClicked()
    {
        Debug.Log("Continue button clicked");
        // TODO: Implement save/load system
        // For now, just load the gameplay scene without resetting
        SceneManager.LoadScene(gameplaySceneName);
    }

    private void OnExitClicked()
    {
        Debug.Log("Exit button clicked - Quitting application");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
