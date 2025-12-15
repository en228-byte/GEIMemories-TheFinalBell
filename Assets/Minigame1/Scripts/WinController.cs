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

        //Time.timeScale = 0f;
        //added for gates
        SceneChanging sceneChanger = new SceneChanging();
        sceneChanger.ChangeScene("gamePlay");
        navigation.gate1 = "td";
        navigation.canMove = true;
        MemoryTracker.lastGood = MemoryTracker.goodMemoriesFound;
        MemoryTracker.lastBad = MemoryTracker.badMemoriesFound;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneChanging sceneChanger = new SceneChanging();
        sceneChanger.ChangeScene("minigame1");
    }
}