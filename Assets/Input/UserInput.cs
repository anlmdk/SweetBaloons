using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 MoveInput { get; set; }

    public static bool IsThrowPressed { get; set; }

    private InputAction moveAction;
    private InputAction throwAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        moveAction = PlayerInput.actions["Move"];
        throwAction = PlayerInput.actions["Throw"];
    }

    private void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();

        IsThrowPressed = throwAction.WasPressedThisFrame();
    }
}
