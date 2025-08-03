using System.Collections.Generic;
using UnityEngine;

public class NPC_Interact : Interactable
{
    public string speakerName;
    public Sprite portrait;
    public List<DialogueLine> dialogueLines;

    public void Start()
    {
        onInteract += StartDialogue;
    }

    public void StartDialogue()
    {
        DialogueManager.Instance?.StartDialogue(this);
    }
}