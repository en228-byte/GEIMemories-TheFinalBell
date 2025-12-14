using System; // Required for the Action delegate
using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // 1. CHANGE: The event now accepts the specific trigger that just finished talking.
    public event Action<NPC_DialogueTrigger> OnDialogueEnd; 
    
    public TextMeshProUGUI textComponent;
    private string[] lines; 
    public float textSpeed = 0.05f; 
    private int index;

    // 2. NEW VARIABLE: Stores which NPC started the current conversation.
    private NPC_DialogueTrigger currentSpeaker; 

    void Start()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(false); 
    }

    void Update()
    {
        if (lines == null || !gameObject.activeSelf) 
        {
            return; 
        }

        bool advanceInput = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E);

        if (advanceInput)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    
    // 3. CHANGE: The method now accepts the speaker argument (the specific NPC instance).
    public void StartConversation(string[] newLines, NPC_DialogueTrigger speaker)
    {
        lines = newLines; 
        currentSpeaker = speaker; // Store the speaker
        
        gameObject.SetActive(true);

        index = 0;
        textComponent.text = string.Empty; 
        StartCoroutine(TypeLine());
    }
    
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // End of conversation:
            lines = null; 
            gameObject.SetActive(false);
            
            // 4. CHANGE: Invoke the event, passing the speaker that just finished.
            OnDialogueEnd?.Invoke(currentSpeaker); 
        }
    }
}