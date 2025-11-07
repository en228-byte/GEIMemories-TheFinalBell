using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    bool[] sides = new bool[5];
    int[] numHits = { 3, 5, 5, 7, 7 };
    float[] speeds = { 5f, 5f, 3f, 3f, 1.5f };
    bool playerSide;
    bool curSide;
    bool notAlreadyHeld = true;
    bool inputLocked = false;

    public int level = 1;
    int index =0;

    DateTime startTime;
    DateTime endTime;
    float timeDown;
    float timeLeft;

    public GameObject leftHand;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        //after starting level by clicking NPC fill in sides[] with what the player will have to click
        for (int i = 0; i < 5; i++)
        {
            float temp = UnityEngine.Random.Range(0f, 1f);
            if (temp > 0.5)
            {
                sides[i] = false; //right
                Debug.Log(sides[i]);
            }
            else
            {
                sides[i] = true; //left
                Debug.Log(sides[i]);
            }
        }

        timeLeft = 5 * speeds[level - 1];
        timeDown = 0.0f;

        leftHand.GetComponent<SpriteRenderer>().color = Color.gray;
        rightHand.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            notAlreadyHeld = true;
            inputLocked = false;
            timeDown = 0;
        }

       if (inputLocked)
        {
            return;
        }

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            inputLocked = true;
            return;
        }
        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft);

        curSide = sides[index];

        if (Input.GetMouseButton(0) && curSide && timeDown < 1.0)
        {
            leftHand.GetComponent<SpriteRenderer>().color = Color.red;
            timeDown += Time.deltaTime;
            playerSide = true;
        }
        else if (curSide)
        {
            leftHand.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            leftHand.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (Input.GetMouseButton(1) && !curSide && timeDown < 1.0)
        {
            rightHand.GetComponent<SpriteRenderer>().color = Color.red;
            timeDown += Time.deltaTime;
            playerSide = false;
        }
        else if (!curSide)
        {
            rightHand.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            rightHand.GetComponent<SpriteRenderer>().color = Color.black;
        }

        if ((Input.GetMouseButton(0) && !curSide) || (Input.GetMouseButton(1) && curSide))
        {
            inputLocked = true;
            return;
        }

        if (timeLeft > 0.0f && notAlreadyHeld)
        {
            if (playerSide == curSide && timeDown > 1)
            {
                notAlreadyHeld = false;
                if (index + 1 < sides.Length)
                {
                    Debug.Log(curSide);
                    index += 1;
                    timeDown = 0;
                }
                else
                {
                    if (level + 1 < 6)
                    {
                        level += 1;
                        Debug.Log("level" + level);
                        Start();
                    }
                    else
                    {
                        Debug.Log("You win, gate unlocked");
                        leftHand.SetActive(false);
                        rightHand.SetActive(false);
                        //load gameplay scene
                    }
                }
            }
        }

        //sets colors of hands based on mouse click and curSide
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

    }

    private void checkHits(float timeDown)
    {
        
    }
}
