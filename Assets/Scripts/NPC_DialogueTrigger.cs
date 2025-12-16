using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic; 

public class NPC_DialogueTrigger : MonoBehaviour
{
    /*public Dialogue dialogueSystem;

    public string[] dialogueLines_Initial; 
    
    public string[] dialogueLines_FollowUp; 

    private bool playerInRange = false;
    
    private bool hasCompletedInitialDialogue = false; 

    void Start()
    {

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
                    dialogueSystem.StartConversation(linesToUse, this); 
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
        if (other.CompareTag("Player")) 
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    */
}