using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Vector2 Size => transform.localScale;

    [Header("Parameters")]
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _jumpForce;

    private PlayerInput _input;
    private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Animator _animator;

    private bool _isJumping;

    private void Awake()
    {
        Instance = this;

        _input = GetComponent<PlayerInput>();
        _groundChecker = GetComponent<GroundChecker>();

        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>(true);
        _animator = GetComponentInChildren<Animator>(true);

        _input.HorizontalMove += OnHorizontalMove;
        _input.JumpKeyPressed += OnJumpKeyPressed;
    }
    private void FixedUpdate()
    {
        var isGrounded = _groundChecker.IsGrounded;

        if (_isJumping)
        {
            _isJumping = isGrounded;
            _animator.SetBool("IsGrounded", false);
        }
        else
        {
            _animator.SetBool("IsGrounded", isGrounded);
        }
        
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
        if (direction != 0)
            _renderer.flipX = direction < 0;

        var speed = Mathf.Abs(direction);
        _animator.SetFloat("Speed", speed);
        _animator.SetFloat("AnimationSpeed", speed * 2f);

        var horizontalForce = direction * _horizontalSpeed;
        _rigidbody.velocity = new Vector2(horizontalForce, _rigidbody.velocity.y);
    }
    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        _isJumping = true;

        _animator.SetBool("IsGrounded", false);
        _animator.SetTrigger("Jumping");
    }
}