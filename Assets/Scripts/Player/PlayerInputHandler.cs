using UnityEngine;
using UnityEngine.InputSystem;

// handles the input recived from player devices, so anyone can play online regarldess of control type

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();

        playerInput = new PlayerInput();

        playerInput.Player.Move.performed += OnMove;
        playerInput.Player.Move.canceled += OnMoveCanceled;
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();

        playerInput.Player.Move.performed -= OnMove;
        playerInput.Player.Move.canceled -= OnMoveCanceled;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        Vector2 direction = Vector2.zero;

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            direction = new Vector2(Mathf.Sign(input.x), 0);
        }
        else
        {
            direction = new Vector2(0, Mathf.Sign(input.y));
        }

        movementController.SetInput(direction);
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        movementController.SetInput(Vector2.zero);
    }


}
