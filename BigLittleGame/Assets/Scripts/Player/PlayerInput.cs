using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<float> HorizontalMove;
    public event Action JumpKeyPressed;

    private void Update()
    {
        var horizontalMove = GetHorizontalAxis();
        HorizontalMove?.Invoke(horizontalMove);

        if (IsJumpKeyPressed())
            JumpKeyPressed?.Invoke();
    }

    private float GetHorizontalAxis()
        => Input.GetAxis("Horizontal");
    private bool IsJumpKeyPressed()
        => Input.GetKeyDown(KeyCode.Space)
        || Input.GetKeyDown(KeyCode.W)
        || Input.GetKeyDown(KeyCode.UpArrow);
}