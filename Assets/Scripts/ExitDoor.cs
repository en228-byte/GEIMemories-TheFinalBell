using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    [Header("Settings")]
    public int memoriesRequired = 5;

    [Header("References (Auto-found if not set)")]
    public TMP_Text messageText;
    public EndingManager endingManager;

    [Header("Messages")]
    public string notEnoughMemoriesMessage = "I should explore more first...";
    public string exitPromptMessage = "Press [E] to leave";

    private bool playerInRange = false;
    private float messageTimer = 0f;
    private bool isShowingMessage = false;

    void Start()
    {
        // Auto-find EndingManager if not assigned
        if (endingManager == null)
        {
            endingManager = FindObjectOfType<EndingManager>();
            if (endingManager != null)
            {
                Debug.Log("ExitDoor: Auto-found EndingManager");
            }
        }

        // Auto-find thought bubble from navigation if messageText not assigned
        if (messageText == null)
        {
            navigation nav = FindObjectOfType<navigation>();
            if (nav != null && nav.thoughtBubble != null)
            {
                messageText = nav.thoughtBubble;
                Debug.Log("ExitDoor: Auto-found thoughtBubble from navigation");
            }
        }
    }

    void Update()
    {
        if (isShowingMessage)
        {
            messageTimer += Time.deltaTime;
            if (messageTimer >= 2f)
            {
                messageText.text = "";
                messageTimer = 0f;
                isShowingMessage = false;
            }
        }

        if (playerInRange && Input.GetKeyUp(KeyCode.E))
        {
            TryExit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<playerMovement>() != null)
        {
            playerInRange = true;
            ShowMessage(exitPromptMessage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<playerMovement>() != null)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<playerMovement>() != null)
        {
            playerInRange = false;
            if (messageText != null)
            {
                messageText.text = "";
            }
        }
    }

    private void TryExit()
    {
        int totalMemories = MemoryTracker.goodMemoriesFound + MemoryTracker.badMemoriesFound;

        if (totalMemories >= memoriesRequired)
        {
            if (endingManager != null)
            {
                endingManager.PlayEnding();
            }
            else
            {
                Debug.LogError("ExitDoor: EndingManager reference is not set!");
            }
        }
        else
        {
            ShowMessage(notEnoughMemoriesMessage);
            Debug.Log($"Not enough memories. Have {totalMemories}, need {memoriesRequired}");
        }
    }

    private void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            isShowingMessage = true;
            messageTimer = 0f;
        }
    }
}
