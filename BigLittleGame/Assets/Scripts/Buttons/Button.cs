using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private float _sizeToEnable;
    [SerializeField]
    private GameObject[] _doors;
    private bool _isActive = false;

    private SpriteRenderer ButtonRenderer;
    private void Awake()
    {
        ButtonRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(!_isActive && player != null && player.Size.y >= _sizeToEnable)
        {
            ButtonRenderer.color = new Color(61, 255, 66, 255);
            DisactivateDoors();
            _isActive = true;
        }
        Debug.Log("Кнопка нажата");
    }
    private void DisactivateDoors()
    {
        foreach(GameObject door in _doors)
        {
            door.SetActive(false);
        }
    }
}
