using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Platform : MonoBehaviour
{
    [SerializeField]
    private Vector2 _enterSize;
    private CircleCollider2D _platformTrigger;
    private EdgeCollider2D _platformCollider;
    private void Awake()
    {
        _platformTrigger = GetComponent<CircleCollider2D>();
        _platformCollider = GetComponent<EdgeCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null && player.Size == _enterSize)
        {
            _platformCollider.isTrigger = false;
        }
        if (player != null && player.Size != _enterSize)
        {
            _platformCollider.isTrigger = true;
        }
    }
}
