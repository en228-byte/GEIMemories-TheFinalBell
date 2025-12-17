using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public event Action<NPC_DialogueTrigger> OnDialogueEnd;

    public TextMeshProUGUI textComponent;
    public string[] lines;  
    public float textSpeed = 0.05f;
    private int index;

    private NPC_DialogueTrigger currentSpeaker;

    public npcNoise voice;

    void Start()
    {
        textComponent.text = string.Empty;

        if (lines != null && lines.Length > 0)
        {
            StartDialogue();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (lines == null || lines.Length == 0 || !gameObject.activeSelf)
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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void StartConversation(string[] newLines, NPC_DialogueTrigger speaker)
    {
        lines = newLines;
        currentSpeaker = speaker;

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
            if (voice != null)
            {
                voice.playNPC();
            }
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);

            OnDialogueEnd?.Invoke(currentSpeaker);

            if (currentSpeaker == null)
            {
                SceneChanging sceneChanger = new SceneChanging();
                sceneChanger.ChangeScene("gamePlay");
            }

            lines = null;
        }
    }
}
