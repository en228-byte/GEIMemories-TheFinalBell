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
        if (dialogueSystem == null)
        {
            dialogueSystem = FindObjectOfType<Dialogue>(true);
        }

        if (dialogueSystem != null)
        {
            dialogueSystem.OnDialogueEnd += OnDialogueFinished;
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
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueSystem != null && !dialogueSystem.gameObject.activeSelf)
            {
                string[] linesToUse = hasCompletedInitialDialogue ? dialogueLines_FollowUp : dialogueLines_Initial;

                if (linesToUse != null && linesToUse.Length > 0)
                {
                    dialogueSystem.StartConversation(linesToUse, this);
                }
            }
        }
    }

    private void OnDialogueFinished(NPC_DialogueTrigger finishedSpeaker)
    {
        if (finishedSpeaker == this && !hasCompletedInitialDialogue)
        {
            hasCompletedInitialDialogue = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayer(other.gameObject))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsPlayer(other.gameObject))
        {
            playerInRange = false;
        }
    }

    private bool IsPlayer(GameObject obj)
    {
        if (obj.CompareTag("Player")) return true;
        if (obj.name == "ray" || obj.name == "ray(Clone)") return true;
        if (obj.name == "updatedray" || obj.name == "updatedray(Clone)") return true;
        return false;
    }
}
