using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public GameObject winPanel;

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void ShowWin()
    {
        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}