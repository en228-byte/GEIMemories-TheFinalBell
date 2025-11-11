using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    //added for gate mechanics
    float timer = 10;

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

    //editted for gate mechanics
    public void RetryClicked()
    {
        SceneChanging sceneChanger = new SceneChanging();
        sceneChanger.ChangeScene("minigame2");
        SceneManager.UnloadSceneAsync("minigame2");
    }

    //added for gate mechanics
    private void Update()
    {
        Debug.Log("You win");
        timer -= Time.deltaTime;
        if (timer <= 0 && !GameOverCanvas.gameObject.activeSelf)
        {
            SceneChanging sceneChanger = new SceneChanging();
            sceneChanger.ChangeScene("gamePlay");
            navigation.gate2 = "h";
            navigation.canMove = true;
        }
    }
}
