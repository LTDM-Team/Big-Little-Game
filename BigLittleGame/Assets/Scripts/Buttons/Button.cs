using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private float _minSizeToEnable;
    [SerializeField] private GameObject[] _doors;
    
    private bool _isActive = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(!_isActive && player != null && player.Size.y >= _minSizeToEnable)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);

            DisactivateDoors();
            _isActive = true;
        }
    }
    private void DisactivateDoors()
    {
        foreach(GameObject door in _doors)
        {
            door.SetActive(false);
        }
    }
}
