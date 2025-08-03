using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NarrativeEvent", menuName = "Scriptable Objects/NarrativeEvent")]
public class NarrativeEvent : ScriptableObject
{
    public string tag;
    public bool isBombEvent = false;
    public List<DialogueLine> dialogueLines;
    public NarrativeEvent nextEvent;
}
