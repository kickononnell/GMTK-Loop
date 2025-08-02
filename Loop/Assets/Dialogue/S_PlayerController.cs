using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    public PlayerInputActions playerControls;
    private InputAction moveAction;
    private InputAction interactAction;

    Vector2 moveDir = Vector2.zero;

    [HideInInspector]
    public NPC_Interact currentInteractable = null;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        moveAction = playerControls.Player.Move;
        moveAction.Enable();

        interactAction = playerControls.Player.Interact;
        interactAction.Enable();

        interactAction.performed += Interact;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        interactAction.Disable();
        interactAction.performed -= Interact;
    }

    private void Update()
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (currentInteractable != null)
        {
            currentInteractable.TriggerDialogue();
            currentInteractable = null;  // Optionally clear so repeated presses advance dialogue
        }
        else if (DialogueManager.Instance != null && DialogueManager.Instance.IsTypingOrOpen())
        {
            DialogueManager.Instance.DisplayNextLine();
        }
    }
}
