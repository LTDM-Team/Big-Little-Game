using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    [SerializeField] private KeyCode _reloadKey;

    private void Update()
    {
        if (Input.GetKeyDown(_reloadKey))
            RestartScene();
    }

    private void RestartScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}