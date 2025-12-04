using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class navigation : MonoBehaviour
{

    protected string[,] schoolMap = { {"o", "o", "cl",  "o",  "o",  "o"},
                                      {"o", "o", "lr",  "lr", "lr", "lo"},
                                      {"o", "o", "o",   "o",  "o",  "td" },
                                      {"lo","lr","lr",  "lo", "lr", "g"},
                                      {"td","l", "o",   "ca", "o",  "o"},
                                      {"td","o", "o",   "o",  "o",  "o"},
                                      {"lr","lr","lr",  "lr", "lo", "o"},
                                      {"o", "o", "o",   "o",  "td",  "o" },
                                      {"o", "o", "o",   "o",  "lr",  "p"},
                                      {"o", "o", "o",   "o",  "o",  "o"} };
    int curRow;
    int curCol;
    public static string gate1;
    public static string gate2;
    public static string gate3;
    public static string gate4;
    public static string exitGate;
    string[] gates;
    public static bool canMove = true;

    public GameObject playerChar;
    public GameObject curBackground;

    public GameObject hallway;
    public GameObject tdHallway;
    public GameObject classroom;
    public GameObject gym;
    public GameObject cafeteria;
    public GameObject library;
    public GameObject office;

    //debugging
    public TMP_Text debugPos;
    public float timer;

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
        playerChar.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        curBackground.transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
        curBackground.tag = "hide";
        curBackground.name = "cl";
        playerChar.tag = "hide";
        gates = new string[4];
        gates[0] = gate1;
        gates[1] = gate2;
        gates[2] = gate3;
        gates[3] = gate4;

        //for debugging
        timer = 0;
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

        //debugging pos
        Collider2D cur = playerChar.GetComponent<Collider2D>();
        timer += Time.deltaTime;
        debugPos.text = timer.ToString();

        //checks where player is, to make sure they are someone where it makes sense they can change areas
        //going right
        if (playerChar.transform.position.x >= 17)
        {
            //activate move command with E key
            if (Input.GetKeyUp(KeyCode.E))
            {
                //check if space is valid area

                try
                {
                    //going right
                    if (schoolMap[curRow, curCol + 1] != "o" && schoolMap[curRow, curCol + 1] != "lo")
                    {
                        //switching player to appropriate place in new area
                        playerChar.transform.position = new Vector3(-16.5f, playerChar.transform.position.y, playerChar.transform.position.z);
                        //change location to the next one
                        curCol += 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        curBackground.name = schoolMap[curRow, curCol];
                        Debug.Log(schoolMap[curRow, curCol]);
                        curBackground.tag = "hide";


                        
                    }
                    else if (schoolMap[curRow, curCol + 1] == "lo")
                    {
                        Debug.Log("Press space to unlock");

                    }
                    else
                    {
                        Debug.Log("There's nothing there...");
                    }
                }
                catch (System.IndexOutOfRangeException)
                {

                    Debug.Log("There's nothing there...");
                }

               
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (schoolMap[curRow, curCol +1] == "lo")
                {
                    int index = 1;
                    foreach (string gate in gates)
                    {
                        if (gate == "lo" && canMove)
                        {
                            Debug.Log("test1");
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame"+index);
                            canMove = false;
                            Debug.Log("test2");
                        }
                        index++;
                    }
                }
            }
        }
        //going left
        if (playerChar.transform.position.x <= -17)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                try
                {
                    if (schoolMap[curRow, curCol - 1] != "o" && schoolMap[curRow, curCol - 1] != "lo")
                    {
                        //switching player to appropriate place in new area
                        playerChar.transform.position = new Vector3(16.5f, playerChar.transform.position.y, playerChar.transform.position.z);
                        //change location to the next one
                        curCol -= 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        curBackground.name = schoolMap[curRow, curCol];
                        Debug.Log(schoolMap[curRow, curCol]);
                        curBackground.tag = "hide";


                        

                    }
                    else if (schoolMap[curRow, curCol - 1] == "lo")
                    {
                        Debug.Log("Press space to unlock");

                    }
                    else
                    {
                        Debug.Log("There's nothing there...");
                    }
                }
                catch (System.Exception)
                {

                    Debug.Log("There's nothing there...");
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (schoolMap[curRow, curCol - 1] == "lo")
                {
                    int index = 1;
                    foreach (string gate in gates)
                    {
                        Debug.Log(gate1 +  " " + gate);
                        if (gate == "lo" && canMove)
                        {
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame" + index);
                            canMove = false;
                        }
                        index++;
                    }
                }
            }
        }
        //going up
        if (playerChar.transform.position.y >= 6)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                try
                {
                    if (schoolMap[curRow - 1, curCol] != "o" && schoolMap[curRow - 1, curCol] != "lo")
                    {
                        //switching player to appropriate place in new area
                        playerChar.transform.position = new Vector3(playerChar.transform.position.x, -8.5f, playerChar.transform.position.z);
                        //change location to the next one
                        curRow -= 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        curBackground.name = schoolMap[curRow, curCol];
                        Debug.Log(schoolMap[curRow, curCol]);
                        curBackground.tag = "hide";


                        

                    }
                    else if (schoolMap[curRow - 1, curCol] == "lo")
                    {
                        Debug.Log("Press space to unlock");

                    }
                    else
                    {
                        Debug.Log("There's nothing there...");
                    }
                }
                catch (System.Exception)
                {

                    Debug.Log("There's nothing there...");
                }
                
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (schoolMap[curRow - 1, curCol] == "lo")
                {

                    int index = 1;
                    foreach (string gate in gates)
                    {
                        if (gate == "lo" && canMove)
                        {
                            Debug.Log("test1");
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame" + index);
                            canMove = false;
                            Debug.Log("test2");
                        }
                        index++;
                    }
                }
            }
        }
        //going down
        if (playerChar.transform.position.y <= -9)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                try
                {
                    if (schoolMap[curRow + 1, curCol] != "o" && schoolMap[curRow + 1, curCol] != "lo")
                    {
                        //switching player to appropriate place in new area
                        playerChar.transform.position = new Vector3(playerChar.transform.position.x, 6f, playerChar.transform.position.z);
                        //change location to the next one
                        curRow += 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        curBackground.name = schoolMap[curRow, curCol];
                        Debug.Log(schoolMap[curRow, curCol]);
                        curBackground.tag = "hide";


                        

                    }
                    else if (schoolMap[curRow + 1, curCol] == "lo")
                    {
                        Debug.Log("Press space to unlock");

                    }
                    else
                    {
                        Debug.Log("There's nothing there...");

                    }
                }
                catch (System.Exception)
                {

                    Debug.Log("There's nothing there...");
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (schoolMap[curRow + 1, curCol] == "lo")
                {
                    int index = 1;
                    foreach (string gate in gates)
                    {
                        if (gate == "lo" && canMove)
                        {
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame" + index);
                            canMove = false;
                        }
                        index++;
                    }
                }
            }
        }        
    }
    void changeBackground(string newBackground)
    {
        Destroy(curBackground);
        if (newBackground == "lr")
        {
            curBackground = Instantiate(hallway);
            playerChar.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        if (newBackground == "td")
        {
            curBackground = Instantiate(tdHallway);
            playerChar.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            playerChar.transform.position = new Vector3(0f, 0f, 0f);
        }
        if (newBackground == "cl")
        {
            curBackground = Instantiate(classroom);
            playerChar.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        if (newBackground == "ca")
        {
            curBackground = Instantiate(cafeteria);
            playerChar.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (newBackground == "p")
        {
            curBackground = Instantiate(office);
            playerChar.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (newBackground == "l")
        {
            curBackground = Instantiate(library);
            playerChar.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
        if (newBackground == "g")
        {
            curBackground = Instantiate(gym);
            playerChar.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        curBackground.transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
    }
}
