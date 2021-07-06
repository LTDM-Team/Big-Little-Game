using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Platform : MonoBehaviour
{
    [SerializeField] private float _maxPlayerSize;

    private EdgeCollider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<EdgeCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            OnPlayerEnter(player);
    }
    private void OnPlayerEnter(Player player)
    {
        var canMove = player.Size.y <= _maxPlayerSize;
        _collider.isTrigger = canMove == false;
    }
}
