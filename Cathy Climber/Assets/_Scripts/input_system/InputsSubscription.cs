using UnityEngine;
using UnityEngine.InputSystem;

public class InputsSubscription : MonoBehaviour
{
    public Vector3 MoveInput {get; private set; } = Vector3.zero;
    public bool MenuInput {get; private set; } = false;
    public bool ActionInput {get; private set; } = false;
    public bool JumpInput {get; private set; } = false;

    Input_map _Input = null;

    private void OnEnable()  // subscribe to Inputs
    {
        _Input = new Input_map();

        _Input.PlayerInput.Enable();

        _Input.PlayerInput.Movement.performed += SetMovement;
        _Input.PlayerInput.Movement.canceled += SetMovement;

        _Input.PlayerInput.ActionInput.performed += SetAction;
        _Input.PlayerInput.ActionInput.canceled += SetAction;
    }

    private void OnDisable()  // unsubscribe to Inputs
    {
        _Input.PlayerInput.Movement.performed -= SetMovement;
        _Input.PlayerInput.Movement.canceled -= SetMovement;

        _Input.PlayerInput.ActionInput.started -= SetAction;
        _Input.PlayerInput.ActionInput.canceled -= SetAction;

        _Input.PlayerInput.Disable();
    }

    private void Update()
    {
        MenuInput = _Input.PlayerInput.MenuInput.WasPressedThisFrame();
        JumpInput = _Input.PlayerInput.JumpInput.WasPressedThisFrame();
        ActionInput = _Input.PlayerInput.ActionInput.WasPressedThisFrame();
    }

    // Perform Context Callback reading
    void SetMovement(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector3>();
    }

    void SetAction(InputAction.CallbackContext ctx)
    {
        ActionInput = ctx.started;
    }

    void SetJump(InputAction.CallbackContext ctx)
    {
        JumpInput = ctx.started;
    }
}
