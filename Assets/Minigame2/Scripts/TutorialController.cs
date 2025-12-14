using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public Canvas tutorialCanvas;

    public void StartGame()
    {
        tutorialCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f; // unpause game
    }
}
