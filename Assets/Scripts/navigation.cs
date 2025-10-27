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
        gate1 = schoolMap[0, 5];
        gate2 = schoolMap[1, 3];
        gate3 = schoolMap[1, 1];
        gate4 = schoolMap[3, 5];
        exitGate = schoolMap[4, 4];
        curBackground = Instantiate(classroom);
        playerChar = Instantiate(playerChar);
    }

    // Update is called once per frame
    void Update()
    {
        //checks where player is, to make sure they are someone where it makes sense they can change areas
        //going right
        if (playerChar.transform.position.x >= 8.15)
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
                    schoolMap[curRow, curCol + 1] = "h";
                    Debug.Log("unlocked");
                }
            }
        }
        //going left
        if (playerChar.transform.position.x <= -8.25)
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
                if (schoolMap[curRow, curCol -1] == "lo")
                {
                    schoolMap[curRow, curCol -1] = "h";
                    Debug.Log("unlocked");
                }
            }
        }
        //going up
        if (playerChar.transform.position.y >= 3.5)
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
                if (schoolMap[curRow - 1, curCol] == "lo")
                {
                    schoolMap[curRow - 1, curCol] = "h";
                    Debug.Log("unlocked");
                }
            }
        }
        //going down
        if (playerChar.transform.position.y <= -4.0)
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
                if (schoolMap[curRow + 1, curCol] == "lo")
                {
                    schoolMap[curRow + 1, curCol] = "h";
                    Debug.Log("unlocked");
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
