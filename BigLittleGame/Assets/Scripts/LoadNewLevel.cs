using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class LoadNewLevel : MonoBehaviour
{
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
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }
}
