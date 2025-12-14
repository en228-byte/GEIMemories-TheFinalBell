using UnityEngine;
using System; // Required for Action event subscription
using System.Collections; // Still needed for MonoBehaviour functions
using System.Collections.Generic; // Still needed for MonoBehaviour functions

public class NPC_DialogueTrigger : MonoBehaviour
{
    [Tooltip("Drag the GameObject with the Dialogue script here.")]
    public Dialogue dialogueSystem;

    [Header("Dialogue Sets")]
    [Tooltip("The lines for the FIRST time the player talks to the NPC.")]
    public string[] dialogueLines_Initial; 
    
    [Tooltip("The lines for subsequent interactions after the first time.")]
    public string[] dialogueLines_FollowUp; 

    private bool playerInRange = false;
    
    // Tracks whether the initial dialogue has been played (starts false).
    private bool hasCompletedInitialDialogue = false; 

    void Start()
    {
        // Subscribe to the Dialogue system's event, expecting the speaker as an argument.
        if (dialogueSystem != null)
        {
            // NOTE: The signature must match the event: OnDialogueEnd(NPC_DialogueTrigger speaker)
            dialogueSystem.OnDialogueEnd += OnDialogueFinished;
        }
    }

    void OnDestroy()
    {
        // Always unsubscribe when the object is destroyed to prevent errors.
        if (dialogueSystem != null)
        {
            dialogueSystem.OnDialogueEnd -= OnDialogueFinished;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Only start dialogue if the dialogue box is currently inactive
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
                
                // Start the conversation with the chosen lines
                if (linesToUse != null && linesToUse.Length > 0)
                {
                    // CRITICAL CHANGE: Pass 'this' to the Dialogue system to identify the speaker
                    dialogueSystem.StartConversation(linesToUse, this); 
                }
            }
        }
    }
    
    // CRITICAL CHANGE: The method now accepts the speaker that finished the dialogue.
    private void OnDialogueFinished(NPC_DialogueTrigger finishedSpeaker)
    {
        // *** FILTER CHECK ***
        // Ignore the event unless this specific instance is the one that just finished talking.
        if (finishedSpeaker != this)
        {
            return;
        }

        // If we reach here, this NPC (and ONLY this NPC) updates its state.
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
}