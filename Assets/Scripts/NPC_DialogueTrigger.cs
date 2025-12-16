using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic; 

public class NPC_DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueSystem;

    public string[] dialogueLines_Initial; 
    
    public string[] dialogueLines_FollowUp; 

    private bool playerInRange = false;
    
    private bool hasCompletedInitialDialogue = false; 

    void Start()
    {
        // Auto-find dialogue system if not assigned
        if (dialogueSystem == null)
        {
            dialogueSystem = FindObjectOfType<Dialogue>(true); // true to include inactive objects
        }

        if (dialogueSystem != null)
        {
            dialogueSystem.OnDialogueEnd += OnDialogueFinished;
        }
        else
        {
            Debug.LogWarning($"NPC_DialogueTrigger on {gameObject.name}: No Dialogue system found in scene!");
        }
    }

    void OnDestroy()
    {
        if (dialogueSystem != null)
        {
            dialogueSystem.OnDialogueEnd -= OnDialogueFinished;
        }
    }

    void Update()
    {
        // Debug: Check if E is pressed at all
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"[{gameObject.name}] E pressed. playerInRange={playerInRange}, dialogueSystem={(dialogueSystem != null ? "found" : "NULL")}");

            if (!playerInRange)
            {
                Debug.Log($"[{gameObject.name}] Player not in range - trigger not detected");
            }
            else if (dialogueSystem == null)
            {
                Debug.Log($"[{gameObject.name}] DialogueSystem is NULL!");
            }
            else if (dialogueSystem.gameObject.activeSelf)
            {
                Debug.Log($"[{gameObject.name}] DialogueBox is already active (dialogue in progress)");
            }
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueSystem != null && !dialogueSystem.gameObject.activeSelf)
            {
                string[] linesToUse;

                if (hasCompletedInitialDialogue)
                {
                    linesToUse = dialogueLines_FollowUp;
                }
                else
                {
                    linesToUse = dialogueLines_Initial;
                }

                if (linesToUse != null && linesToUse.Length > 0)
                {
                    Debug.Log($"[{gameObject.name}] Starting dialogue with {linesToUse.Length} lines");
                    dialogueSystem.StartConversation(linesToUse, this);
                }
                else
                {
                    Debug.Log($"[{gameObject.name}] No dialogue lines to show!");
                }
            }
        }
    }
    
    private void OnDialogueFinished(NPC_DialogueTrigger finishedSpeaker)
    {
        if (finishedSpeaker != this)
        {
            return;
        }

        if (!hasCompletedInitialDialogue)
        {
            hasCompletedInitialDialogue = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[{gameObject.name}] OnTriggerEnter2D: {other.gameObject.name} (tag: {other.tag})");
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log($"[{gameObject.name}] Player entered range!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log($"[{gameObject.name}] Player exited range");
        }
    }
}