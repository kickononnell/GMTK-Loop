using System;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public delegate void OnInteract();
    public OnInteract onInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

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

    public void AddInteraction(OnInteract onInteract)
    {
        this.onInteract += onInteract;
    }

    public void SetInteraction(OnInteract onInteract)
    {
        this.onInteract = onInteract;
    }

    public void Interact()
    {
        onInteract?.Invoke();
        onInteract = null;
    }
}
