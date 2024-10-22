using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 MoveInput { get; set; }
    public static Vector2 MouseDelta { get; set; }

    public static bool IsMouseMoving { get; set; }
    public static bool IsThrowPressed { get; set; }

    private InputAction moveAction;
    private InputAction mouseMoveAction;
    private InputAction throwAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        moveAction = PlayerInput.actions["Move"];
        mouseMoveAction = PlayerInput.actions["Look"];
        throwAction = PlayerInput.actions["Throw"];
    }

    private void Update()
    {
        // Klavye hareketini al
        MoveInput = moveAction.ReadValue<Vector2>();

        // Fare hareketini al (Mouse Delta)
        MouseDelta = mouseMoveAction.ReadValue<Vector2>();
        IsMouseMoving = MouseDelta != Vector2.zero;

        IsThrowPressed = throwAction.WasPressedThisFrame();
    }
}
