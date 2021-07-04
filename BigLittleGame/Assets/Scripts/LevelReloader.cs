using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private KeyCode _reloadKey;
    private void Update()
    {
        if(Input.GetKeyDown(_reloadKey))
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
