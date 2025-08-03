using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerController : MonoBehaviour
{
    //public Rigidbody rb;
    //public float moveSpeed = 5f;

    public PlayerInputActions playerControls;
    //private InputAction moveAction;
    private InputAction interactAction;

    Vector2 moveDir = Vector2.zero;

    [HideInInspector]
    public Interactable currentInteractable = null;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        //moveAction = playerControls.Player.Move;
        //moveAction.Enable();

        interactAction = playerControls.Player.Interact;
        interactAction.Enable();
    }

    private void OnDisable()
    {
        //moveAction.Disable();
        interactAction.Disable();
    }

    public void Interact()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
            currentInteractable = null;  // Optionally clear so repeated presses advance dialogue
        }
        else if (DialogueManager.Instance != null && DialogueManager.Instance.IsTypingOrOpen())
        {
            DialogueManager.Instance.DisplayNextLine();
        }
    }
}
