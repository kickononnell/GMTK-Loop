using UnityEngine;

public class NarrativeSystem : MonoBehaviour
{
    private NarrativeEvent narrativeEvent;
    public Interactable tnt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        AddEvent(new StartEvent());
    }

    void AddEvent(NarrativeEvent newEvent)
    {
        narrativeEvent = newEvent;
        narrativeEvent.interactable.onInteract += narrativeEvent.Event;
    }
}
