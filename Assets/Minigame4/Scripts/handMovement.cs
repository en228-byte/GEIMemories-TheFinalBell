using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    bool[] sides = new bool[5];
    float[] speeds = { 5f, 5f, 3f, 3f, 2f };
    bool playerSide;
    bool curSide;
    bool notAlreadyHeld = true;
    bool inputLocked = false;
    bool timerCount = false;

    public int level = 1;
    int index =0;

    public TMP_Text timerDisplay;
    public TMP_Text levelDisplay;

    float timeDown;
    float timeLeft;

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject instructions;
    public GameObject retryButton;
    public GameObject mirror1;
    public GameObject mirror2;
    public GameObject mirror3;
    public GameObject mirror4;
    public GameObject mirror5;

    AudioSource soundEffects;
    public AudioClip lastShatter;
    public AudioClip levelBeatShatter;
    public AudioClip mirrorCrack;

    // Start is called before the first frame update
    void Start()
    {
        instructions.SetActive(true);
        retryButton.SetActive(false);
        soundEffects = GetComponent<AudioSource>();
        mirror1.SetActive(false);
        mirror2.SetActive(false);
        mirror3.SetActive(false);
        mirror4.SetActive(false);
        mirror5.SetActive(false);
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

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            inputLocked = true;
        }

        if (timerCount)
        {
            timeLeft -= Time.deltaTime;
            timerDisplay.text = timeLeft.ToString("f2");
        }

        curSide = sides[index];

        if (Input.GetMouseButton(0) && curSide && timeDown < 1.0 && !inputLocked)
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

        if (Input.GetMouseButton(1) && !curSide && timeDown < 1.0 && !inputLocked)
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
        }

        if (timeLeft > 0.0f && notAlreadyHeld)
        {
            if (playerSide == curSide && timeDown >= 1)
            {
                notAlreadyHeld = false;
                if (index + 1 < sides.Length)
                {
                    soundEffects.clip = mirrorCrack;
                    soundEffects.Play();
                    index += 1;
                    timeDown = 0;
                }
                else
                {
                    if (level + 1 < 6)
                    {
                        soundEffects.clip = levelBeatShatter;
                        soundEffects.Play();
                        level += 1;
                        index = 0;
                        Debug.Log("level" + level);
                        startLevel();
                    }
                    else
                    {
                        soundEffects.clip = lastShatter;
                        soundEffects.Play();
                        mirror5.SetActive(true);
                        timerCount = false;
                        timerDisplay.text = "you beat your reflection but you must still reflect";
                        leftHand.SetActive(false);
                        rightHand.SetActive(false);
                        navigation.gate4 = "td";
                        navigation.canMove = true;
                        MemoryTracker.lastGood = MemoryTracker.goodMemoriesFound;
                        MemoryTracker.lastBad = MemoryTracker.badMemoriesFound;
                    }
                }
            }

            if (level > 1)
            {
                mirror1.SetActive(true);
            }
            if (level > 2)
            {
                mirror2.SetActive(true);
            }
            if (level > 3)
            {
                mirror3.SetActive(true);
            }
            if (level > 4)
            {
                mirror4.SetActive(true);
            }
        }

        //end if timer runs out
        if (timeLeft < 0)
        {
            timerCount = false;
            timerDisplay.text = "You lose. Death awaits";
            retryButton.SetActive(true);
            leftHand.SetActive(false);
            rightHand.SetActive(false);
        }

    }

    public void startLevel()
    {
        levelDisplay.text = "Level: " + level.ToString();
        timerCount = true;
        instructions.SetActive(false);

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

    public void exitMinigame()
    {
        SceneChanging sceneChanger = new SceneChanging();
        sceneChanger.ChangeScene("gamePlay");
    }
}
