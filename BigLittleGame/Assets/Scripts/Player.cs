using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float JumpPower;
    public float Speed;
    private Rigidbody2D _playerRigidbody;
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _playerRigidbody.AddForce(Vector2.up.normalized * JumpPower, ForceMode2D.Impulse);
        }
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * Speed);
    }
}
