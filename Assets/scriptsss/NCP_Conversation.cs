using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCP_Conversation : MonoBehaviour
{
    public DialogueData dialogue;

    public void TriggerDialogue()
    {
        if (dialogue != null)
        {
            foreach (var line in dialogue.lines)
            {
                Debug.Log($"{this.name}: {line.text}");
            }
        }
        else
        {
            Debug.LogWarning("No dialogue assigned to this NPC.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TriggerDialogue();
        }
    }
}
