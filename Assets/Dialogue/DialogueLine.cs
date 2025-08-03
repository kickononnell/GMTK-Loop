using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string text;

    public DialogueLine(string line)
    {
        text = line;
    }
}
