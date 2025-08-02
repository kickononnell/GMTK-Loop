using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public Image portraitImage;
    public TMP_Text dialogueText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    private List<DialogueLine> currentLines;
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartDialogue(NPC_Interact npc)
    {
        if (npc == null || npc.dialogueLines == null || npc.dialogueLines.Count == 0)
            return;

        nameText.text = npc.speakerName;
        portraitImage.sprite = npc.portrait;

        currentLines = npc.dialogueLines;
        currentLineIndex = 0;
        dialoguePanel.SetActive(true);

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (isTyping)
        {
            SkipTyping();
            return;
        }

        if (currentLineIndex >= currentLines.Count)
        {
            EndDialogue();
            return;
        }

        var line = currentLines[currentLineIndex];
        currentLineIndex++;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(line.text));
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        dialogueText.text = currentLines[currentLineIndex - 1].text;
        isTyping = false;
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        nameText.text = "";
        portraitImage.sprite = null;
        currentLines = null;
        currentLineIndex = 0;
    }

    public bool IsTypingOrOpen()
    {
        return isTyping || dialoguePanel.activeSelf;
    }
}