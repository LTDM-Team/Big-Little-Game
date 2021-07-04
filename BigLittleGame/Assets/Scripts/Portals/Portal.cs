using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Portal : MonoBehaviour
{
    public PortalInOutDirection Direction => _direction;
    public float Size { get; private set; }

    [SerializeField] private PortalInOutDirection _direction;
    [SerializeField] private Portal _otherPortal;

    private void Awake()
    {
        var renderer = GetComponent<SpriteRenderer>();
        Size = renderer.size.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Teleport(collision);
    }

    private void Teleport(Collider2D collider)
    {
        var otherTransform = collider.transform;
        var otherPortalPosition = (Vector2)_otherPortal.transform.localPosition;
        var otherPortalDirection = Vector2.zero;

        var colliderSize = (Vector2)collider.bounds.size / otherTransform.lossyScale;
        var colliderHorizontalSize = colliderSize.x / 2f;

        var sizeMultiplier = (_otherPortal.Size - 0.03f) / colliderSize.y;
        var sizeOffset = colliderHorizontalSize * sizeMultiplier;
        var horizontalSizeOffset = sizeOffset * Vector2.right;

        if (_otherPortal.Direction == PortalInOutDirection.Left)
            otherPortalDirection -= horizontalSizeOffset;
        else otherPortalDirection += Vector2.right + horizontalSizeOffset;

        otherTransform.localPosition = otherPortalPosition + otherPortalDirection;
        Resize(otherTransform, sizeMultiplier);

        if (otherTransform.TryGetComponent(out Rigidbody2D body))
            ChangeVelocity(body);
    }
    private void Resize(Transform otherTransform, float scaleMultiplier)
    {
        var isExistRenderer = otherTransform.TryGetComponent(out SpriteRenderer renderer);

        if (isExistRenderer && renderer.drawMode != SpriteDrawMode.Simple)
            renderer.size = scaleMultiplier * Vector2.one;
        else otherTransform.localScale = scaleMultiplier * Vector3.one;
    }
    private void ChangeVelocity(Rigidbody2D body)
    {
        body.velocity *= new Vector2(_otherPortal.Direction.GetVector().x, 1);
    }
}