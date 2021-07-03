﻿using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public Vector2 Size => _renderer.size;

    [Header("Parameters")]
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _jumpForce;

    private PlayerInput _input;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();

        _input.HorizontalMove += OnHorizontalMove;
        _input.JumpKeyPressed += OnJumpKeyPressed;
    }

    private void OnHorizontalMove(float direction)
    {
        Move(direction);
    }
    private void OnJumpKeyPressed()
    {
        if (_groundChecker.IsGrounded)
            Jump();
    }

    private void Move(float direction)
    {
        var horizontalForce = direction * _horizontalSpeed;
        _rigidbody.velocity = new Vector2(horizontalForce, _rigidbody.velocity.y);
    }
    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}