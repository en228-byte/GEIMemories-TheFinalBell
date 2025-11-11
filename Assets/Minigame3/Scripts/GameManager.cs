using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform door;
    public TextMeshProUGUI distanceText;
    public GameObject winPanel;
    public GameObject losePanel;

    private bool frozen = false;

    void Update()
    {
        if (player && door && distanceText)
        {
            float remaining = Mathf.Max(0f, door.position.y - player.position.y);
            distanceText.text = $"Door: {Mathf.CeilToInt(remaining)} m";
        }
    }

    public void Win()
    {
        if (winPanel) winPanel.SetActive(true);
        Freeze();
    }

    public void Lose()
    {
        if (losePanel) losePanel.SetActive(true);
        Freeze();
    }

    void Freeze()
    {
        frozen = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    void Unfreeze()
    {
        frozen = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Retry()
    {
        Unfreeze();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string name)
    {
        Unfreeze();
        SceneManager.LoadScene(name);
    }

    public bool IsFrozen() => frozen;
}