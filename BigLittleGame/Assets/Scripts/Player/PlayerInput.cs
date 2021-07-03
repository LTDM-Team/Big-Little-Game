using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<float> HorizontalMove;
    public event Action JumpKeyPressed;

    private void Update()
    {
        var horizontalDirection = Input.GetAxisRaw("Horizontal");
        HorizontalMove?.Invoke(horizontalDirection);

        if (Input.GetKeyDown(KeyCode.Space))
            JumpKeyPressed?.Invoke();
    }
}