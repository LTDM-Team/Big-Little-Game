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
        Teleport(collision.transform);
    }

    private void Teleport(Transform transform)
    {
        var otherPortalPosition = (Vector2)_otherPortal.transform.localPosition;
        var otherPortalDirection = Vector2.right * 1.1f;

        if (_otherPortal.Direction == PortalInOutDirection.Left)
            otherPortalDirection *= _otherPortal.Size * Vector2.left;
        else  otherPortalDirection *= Vector2.right;

        transform.localPosition = otherPortalPosition + otherPortalDirection;
        Resize(transform);

        if (transform.TryGetComponent(out Rigidbody2D body))
            ChangeVelocity(body);
    }
    private void Resize(Transform transform)
    {
        var isExistRenderer = transform.TryGetComponent(out SpriteRenderer renderer);

        if (isExistRenderer && renderer.drawMode != SpriteDrawMode.Simple)
            renderer.size = _otherPortal.Size * Vector2.one;
        else transform.localScale = _otherPortal.Size * Vector3.one;
    }
    private void ChangeVelocity(Rigidbody2D body)
    {
        body.velocity *= new Vector2(_otherPortal.Direction.GetVector().x, 1);
    }
}