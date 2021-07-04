using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class LoadNewLevel : MonoBehaviour
{
    [SerializeField]
    private int _indexOfSceneToLoad;
    private void Awake()
    {
        BoxCollider2D finishCollider = GetComponent<BoxCollider2D>();
        finishCollider.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            SceneManager.LoadScene(_indexOfSceneToLoad);
        }
    }
}
