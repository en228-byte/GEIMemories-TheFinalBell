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

    [Header("Background Music")]
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private float fadeDuration = 1.5f;

    private Button startButton;
    private Button continueButton;
    private Button exitButton;
    private bool isTransitioning = false;

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

    private void Start()
    {
        if (bgmAudioSource == null)
        {
            bgmAudioSource = GetComponent<AudioSource>();
        }

        if (bgmAudioSource != null && !bgmAudioSource.isPlaying)
        {
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
            Debug.Log("MainMenu: Background music started");
        }
    }

    private void OnDestroy()
    {
        if (startButton != null)
            startButton.clicked -= OnStartClicked;

        if (continueButton != null)
            continueButton.clicked -= OnContinueClicked;

        if (exitButton != null)
            exitButton.clicked -= OnExitClicked;
    }

    private void OnStartClicked()
    {
        if (isTransitioning) return;

        Debug.Log("Start button clicked - Loading gameplay scene");

        // Reset game state when starting new game
        GameState.ResetGameState();

        // Fade out music then load scene
        StartCoroutine(FadeOutAndLoadScene(gameplaySceneName));
    }

    private void OnContinueClicked()
    {
        if (isTransitioning) return;

        Debug.Log("Continue button clicked");
        StartCoroutine(FadeOutAndLoadScene(gameplaySceneName));
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

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        isTransitioning = true;

        if (bgmAudioSource != null)
        {
            float startVolume = bgmAudioSource.volume;
            float elapsed = 0f;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                bgmAudioSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / fadeDuration);
                yield return null;
            }

            bgmAudioSource.Stop();
            bgmAudioSource.volume = startVolume; // Reset for next time
        }

        SceneManager.LoadScene(sceneName);
    }
}
