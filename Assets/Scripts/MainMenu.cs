using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UIDocument mainMenuDocument;

    private Button playButton;
    private Button settingsButton;
    private Button continueButton;

    private void Awake()
    {
        VisualElement root = mainMenuDocument.rootVisualElement;

        playButton = root.Q<Button>("PlayButton");
        settingsButton = root.Q<Button>("SettingsButton");
        continueButton = root.Q<Button>("ContinueButton");



    }


}
