using UnityEngine;

public class Button : MonoBehaviour
{
    private const float PressedScaleMultiplier = 0.5f;

    [SerializeField] private float _minSizeToEnable;
    [SerializeField] private GameObject[] _doors;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            OnPlayerEnter(player);
        }
    }
    private void OnPlayerEnter(Player player)
    {
        var canActivate = player.Size.y >= _minSizeToEnable;
        if (canActivate)
            ActivateButton();
    }
    private void ActivateButton()
    {
        var currentScale = transform.localScale;
        var scaleY = currentScale.y * PressedScaleMultiplier;
        var newScale = new Vector3(currentScale.x, scaleY);

        transform.localScale = newScale;
        this.enabled = false;
        OpenDoors();
    }
    private void OpenDoors()
    {
        foreach(GameObject door in _doors)
        {
            door.SetActive(false);
        }
    }
}
