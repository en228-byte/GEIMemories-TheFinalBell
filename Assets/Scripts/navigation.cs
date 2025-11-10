using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigation : MonoBehaviour
{

    protected string[,] schoolMap = { {"o", "o", "cl", "o", "o", "o"},
                                      {"o", "o", "h",  "h", "h", "lo"},
                                      {"o", "o", "o",  "o", "o", "h" },
                                      {"h", "lo", "h", "lo", "h", "g"},
                                      {"h", "l", "o",  "ca", "o", "o"},
                                      {"h", "o", "o",  "o",  "o", "o"},
                                      {"h", "h", "h",  "h", "h", "lo"},
                                      {"o", "o", "o", "o", "lo", "h" },
                                      {"o", "o", "o",  "o", "h", "p"},
                                      {"o", "o", "o",  "o", "e", "o"} };
    int curRow;
    int curCol;
    public string gate1;
    public string gate2;
    public string gate3;
    public string gate4;
    public string exitGate;
    string[] gates;
    bool canMove = true;

    public GameObject playerChar;
    public GameObject curBackground;

    public GameObject hallway;
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

        curBackground.tag = "hide";
        playerChar.tag = "hide";
        gates = new string[4];
        gates[0] = gate1;
        gates[1] = gate2;
        gates[2] = gate3;
        gates[3] = gate4;
    }

    // Update is called once per frame
    void Update()
    {
        //checks where player is, to make sure they are someone where it makes sense they can change areas
        //going right
        if (playerChar.transform.position.x >= 9.4)
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
                        //change location to the next one
                        curCol += 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        Debug.Log(schoolMap[curRow, curCol]);

                        //switching player to appropriate place in new area
                        playerChar.transform.position = new Vector3(-8.24f, playerChar.transform.position.y, playerChar.transform.position.z);
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
                    //schoolMap[curRow, curCol + 1] = "h";
                    //Debug.Log("unlocked");
                    int index = 1;
                    foreach (string gate in gates)
                    {
                        if (gate == "lo" && canMove)
                        { 
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame"+index);
                            canMove = false;
                        }
                        index++;
                    }
                }
            }
        }
        //going left
        if (playerChar.transform.position.x <= -9.4)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                try
                {
                    if (schoolMap[curRow, curCol - 1] != "o" && schoolMap[curRow, curCol - 1] != "lo")
                    {
                        //change location to the next one
                        curCol -= 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        Debug.Log(schoolMap[curRow, curCol]);

                        //switching player to appropriate place in new area
                        playerChar.transform.position = new Vector3(8.24f, playerChar.transform.position.y, playerChar.transform.position.z);

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
                if (schoolMap[curRow, curCol + 1] == "lo")
                {
                    //schoolMap[curRow, curCol + 1] = "h";
                    //Debug.Log("unlocked");
                    int index = 1;
                    foreach (string gate in gates)
                    {
                        if (gate == "lo")
                        {
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame" + index);
                        }
                        index++;
                    }
                }
            }
        }
        //going up
        if (playerChar.transform.position.y >= 5.3)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                try
                {
                    if (schoolMap[curRow - 1, curCol] != "o" && schoolMap[curRow - 1, curCol] != "lo")
                    {
                        //change location to the next one
                        curRow -= 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        Debug.Log(schoolMap[curRow, curCol]);

                        //switching player to appropriate place in new area
                        playerChar.transform.position = new Vector3(playerChar.transform.position.x, -4.4f, playerChar.transform.position.z);

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (schoolMap[curRow, curCol + 1] == "lo")
                {
                    //schoolMap[curRow, curCol + 1] = "h";
                    //Debug.Log("unlocked");
                    int index = 1;
                    foreach (string gate in gates)
                    {
                        if (gate == "lo")
                        {
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame" + index);
                        }
                        index++;
                    }
                }
            }
        }
        //going down
        if (playerChar.transform.position.y <= -9.3)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                try
                {
                    if (schoolMap[curRow + 1, curCol] != "o" && schoolMap[curRow + 1, curCol] != "lo")
                    {
                        //change location to the next one
                        curRow += 1;
                        changeBackground(schoolMap[curRow, curCol]);
                        Debug.Log(schoolMap[curRow, curCol]);

                        //switching player to appropriate place in new area
                       playerChar.transform.position = new Vector3(playerChar.transform.position.x, -0.6f, playerChar.transform.position.z);

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
                if (schoolMap[curRow, curCol + 1] == "lo")
                {
                    //schoolMap[curRow, curCol + 1] = "h";
                    //Debug.Log("unlocked");
                    int index = 1;
                    foreach (string gate in gates)
                    {
                        if (gate == "lo")
                        {
                            SceneChanging sceneChanger = new SceneChanging();
                            sceneChanger.ChangeScene("minigame" + index);
                        }
                        index++;
                    }
                }
            }
        }


        //space to unlock gates
        
    }
    void changeBackground(string newBackground)
    {
        Destroy(curBackground);
        if (newBackground == "h")
        {
            curBackground = Instantiate(hallway);
        }
        if (newBackground == "cl")
        {
            curBackground = Instantiate(classroom);
        }
        if (newBackground == "ca")
        {
            curBackground = Instantiate(cafeteria);
        }
        if (newBackground == "p")
        {
            curBackground = Instantiate(office);
        }
        if (newBackground == "l")
        {
            curBackground = Instantiate(library);
        }
        if (newBackground == "g")
        {
            curBackground = Instantiate(gym);
        }
    }
}
