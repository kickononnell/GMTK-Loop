using System.Collections.Generic;
using UnityEngine;

public class NPC_Interact : MonoBehaviour
{
    public string speakerName;
    public Sprite portrait;
    public List<DialogueLine> dialogueLines;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerController = other.GetComponent<S_PlayerController>();
            if (playerController != null)
            {
                playerController.currentInteractable = this;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerController = other.GetComponent<S_PlayerController>();
            if (playerController != null && playerController.currentInteractable == this)
            {
                playerController.currentInteractable = null;
            }
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.Instance?.StartDialogue(this);
    }
}