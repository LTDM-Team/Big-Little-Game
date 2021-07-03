using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Collider2D _groundCheckCollider;
    [SerializeField] private LayerMask _groundLayerMask;

    public bool IsGrounded => _groundCheckCollider.IsTouchingLayers(_groundLayerMask);
}