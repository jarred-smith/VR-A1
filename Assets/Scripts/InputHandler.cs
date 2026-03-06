using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerController playerController;
    private InputAction _moveAction, _jumpAction, _lookAction;
    void Start()
    {
        if(Gamepad.all.Count > 0)
        {
            Debug.Log("Gamepad detected");
        }
        else
        {
            Debug.Log("No gamepad detected.");
        }
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction.performed += OnJumpPerformed;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
        playerController.Rotate(lookVector);
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        playerController.Move(movementVector);
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        playerController.Jump();
    }
}
