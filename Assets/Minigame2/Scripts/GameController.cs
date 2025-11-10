using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public Canvas GameOverCanvas;

    private void Awake()
    {
        if(playerController != null)
        {
            playerController.PlayerDied += WhenPlayerDies;
        }
        if (GameOverCanvas.gameObject.activeSelf)
        {
            GameOverCanvas.gameObject.SetActive(false);
        }
    }


    void WhenPlayerDies()
    {
        GameOverCanvas.gameObject.SetActive(true);

        if (playerController != null)
        {
            playerController.PlayerDied -= WhenPlayerDies;
        }
    }

    public void RetryClicked()
    {
        SceneManager.LoadScene("minigame2");
    }
}
