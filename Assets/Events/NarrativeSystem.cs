using System.Collections.Generic;
using UnityEngine;

public class NarrativeSystem : MonoBehaviour
{
    public ManageLoopVideo loopManager;
    public NarrativeEvent narrativeEvent;
    private Interactable interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadEvent();
    }

    public void NextEvent()
    {
        /*if (narrativeEvent.isBombEvent)
        {
            StartCoroutine(loopManager.PlayEndVid());
        }*/
        if (narrativeEvent.nextEvent)
        {
            narrativeEvent = narrativeEvent.nextEvent;
            LoadEvent();
        }
    }

    private void LoadEvent()
    {
        Debug.Log(narrativeEvent.tag);
        interactable = GameObject.FindWithTag(narrativeEvent.tag).GetComponent<Interactable>();
        if (narrativeEvent.dialogueLines.Count > 0 && interactable.GetComponent<NPC_Interact>())
        {
            ((NPC_Interact)interactable).dialogueLines = narrativeEvent.dialogueLines;
            interactable.AddInteraction(((NPC_Interact)interactable).StartDialogue);
        }
        interactable.AddInteraction(NextEvent);
    }
}
