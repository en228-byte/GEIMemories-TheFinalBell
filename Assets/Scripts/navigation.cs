using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class navigation : MonoBehaviour
{

    protected string[,] schoolMap = { {"o", "o", "cl",  "o",  "o",  "o"},
                                      {"o", "o", "lr",  "lr", "lr", "lo"},
                                      {"o", "o", "o",   "o",  "o",  "td" },
                                      {"o","lr","lr",  "lo", "lr", "g"},
                                      {"td","l", "o",   "ca", "o",  "o"},
                                      {"td","o", "o",   "o",  "o",  "o"},
                                      {"lr","lr","lr",  "lr", "lo", "o"},
                                      {"o", "o", "o",   "o",  "td",  "o" },
                                      {"o", "o", "o",   "o",  "sp2",  "p"},
                                      {"o", "o", "o",   "o",  "o",  "o"} };
    int curRow;
    int curCol;
    int nextGateIndex =-1;
    public static string gate1;
    public static string gate2;
    public static string gate3;
    public static string gate4;
    public static string exitGate;
    string[] gates;
    public static bool canMove = true;
    float timer = 0;
    bool isTimer = false;

    public TMP_Text thoughtBubble;
    public GameObject playerChar;
    public GameObject curBackground;
    public GameObject hallway;
    public GameObject tdHallway;
    public GameObject spHallway1;
    public GameObject spHallway2;
    public GameObject classroom;
    public GameObject gym;
    public GameObject cafeteria;
    public GameObject library;
    public GameObject office;

    // Start is called before the first frame update
    void Start()
    {
        curRow = 0;
        curCol = 2;
        gate1 = "lo";
        gate2 = "lo";
        gate3 = "lo";
        gate4 = "lo";
        exitGate = "lo";
        curBackground = Instantiate(classroom);
        playerChar = Instantiate(playerChar);
        playerChar.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        curBackground.transform.localScale = new Vector3(1.85f, 1.85f, 1.85f);
        curBackground.tag = "hide";
        curBackground.name = "cl";
        // Keep player tag as "Player" for NPC dialogue triggers
        gates = new string[4];
        gates[0] = gate1;
        gates[1] = gate2;
        gates[2] = gate3;
        gates[3] = gate4;
    }

    // Update is called once per frame
    void Update()
    {
        schoolMap[1, 5] = gate1;
        schoolMap[3,3] = gate2;
        schoolMap[3, 1] = gate3;
        schoolMap[6,4] = gate4;
        gates[0] = gate1;
        gates[1] = gate2;
        gates[2] = gate3;
        gates[3] = gate4;

        memoryInteraction.hideOutside(curBackground.name);
        if (isTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 1.5)
        {
            thoughtBubble.text = "";
            timer = 0;
            isTimer = false;
        }

        
            //going right
            if (playerChar.transform.position.x >= 16.5)
            {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (switchRooms(curRow, curCol + 1))
                {
                    playerChar.transform.position = new Vector3(0f, playerChar.transform.position.y, 0);
                }
            }
            startMinigame();
            }
            //going left
            if (playerChar.transform.position.x <= -16.5)
            {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (switchRooms(curRow, curCol - 1))
                {
                    playerChar.transform.position = new Vector3(0f, playerChar.transform.position.y, 0);
                }
            }
            startMinigame();
            }
            //going up
            if (playerChar.transform.position.y >= 6.5)
            {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (switchRooms(curRow - 1, curCol))
                {
                    playerChar.transform.position = new Vector3(playerChar.transform.position.x, 0f, 0);
                }
            }
            startMinigame();
            }
            //going down
            if (playerChar.transform.position.y <= -8.5)
            {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (switchRooms(curRow + 1, curCol))
                {
                    playerChar.transform.position = new Vector3(playerChar.transform.position.x, 0f, 0);
                }
            }
            startMinigame();
            }
        
        if (playerChar.transform.position.x >= 17 || playerChar.transform.position.y >= 6  || playerChar.transform.position.x <= -17 || playerChar.transform.position.y <= -9)
        {
            startMinigame();
        }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(playerChar.transform.position + new Vector3(0.0f, 2f, 0f));
            thoughtBubble.GetComponent<RectTransform>().position = screenPos;
    }

    bool switchRooms(int row, int col)
    {
        try
        {
            string next = schoolMap[row, col];
            switch (next)
                {
                    case "o":
                        thoughtBubble.text = "There's nothing there...";
                        isTimer = true;
                    return false;
                    case "lo":
                        thoughtBubble.text = "There's a gate ahead...should I accept the challenge? Press [space] to accept.";
                        isTimer = true;
                    for (int i = 0; i < gates.Length; i++)
                        {
                            if (gates[i] == "lo")
                            {
                                nextGateIndex = i;
                                Debug.Log(nextGateIndex);
                                break;
                            }
                        }
                        return false;
                    default:
                        thoughtBubble.text = "Somewhere new";
                        isTimer = true;
                    changeBackground(next);
                    Debug.Log(next);
                        curCol = col;
                        curRow = row;
                    return true;
                }
        }
        catch (System.Exception)
        {

            thoughtBubble.text = "There's nothing there...";
            isTimer = true;
            return false;
        }
    }
    void changeBackground(string newBackground)
    {
        Destroy(curBackground);
        if (newBackground == "lr")
        {
            curBackground = Instantiate(hallway);
            playerChar.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
        if (newBackground == "td")
        {
            curBackground = Instantiate(tdHallway);
            playerChar.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            playerChar.transform.position = new Vector3(0f, 0f, 0f);
        }
        if (newBackground == "sp1")
        {
            curBackground = Instantiate(spHallway1);
            playerChar.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
        if (newBackground == "sp2")
        {
            curBackground = Instantiate(spHallway2);
            playerChar.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
        if (newBackground == "cl")
        {
            curBackground = Instantiate(classroom);
            playerChar.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
        if (newBackground == "ca")
        {
            curBackground = Instantiate(cafeteria);
            playerChar.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        if (newBackground == "p")
        {
            curBackground = Instantiate(office);
            playerChar.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
        if (newBackground == "l")
        {
            curBackground = Instantiate(library);
            playerChar.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        }
        if (newBackground == "g")
        {
            curBackground = Instantiate(gym);
            playerChar.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }
        curBackground.transform.localScale = new Vector3(1.85f, 1.85f, 1.85f);
        curBackground.name = newBackground;
        curBackground.tag = "hide";
    }
    
    void startMinigame()
    {
        int curSum = MemoryTracker.badMemoriesFound + MemoryTracker.goodMemoriesFound;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (nextGateIndex != -1)
            {
                if (MemoryTracker.badMemoriesFound > MemoryTracker.lastBad || MemoryTracker.goodMemoriesFound > MemoryTracker.lastGood)
                {
                    SceneChanging sceneChanger = new SceneChanging();
                    sceneChanger.ChangeScene("minigame" + (nextGateIndex + 1));
                    nextGateIndex = -1;

                }
                else
                {
                    thoughtBubble.text = "I think I need to find something before I go.";
                    isTimer = true;
                }

            }
        }
    }
}
