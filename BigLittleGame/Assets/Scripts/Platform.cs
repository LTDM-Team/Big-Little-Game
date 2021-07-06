using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Platform : MonoBehaviour
{
    [SerializeField] private float _minSizeToEnable;

    private EdgeCollider2D _platformCollider;
    private void Awake()
    {
        _platformCollider = GetComponent<EdgeCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null && player.Size.y >= _minSizeToEnable)
        {
            _platformCollider.isTrigger = false;
        }
        else if (player != null && player.Size.y < _minSizeToEnable)
        {
            _platformCollider.isTrigger = true;
        }
    }
}
