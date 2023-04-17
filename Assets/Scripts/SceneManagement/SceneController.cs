using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneList _sceneList;

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        _sceneList.CurrentScene++;
        SceneManager.LoadScene(_sceneList.Scenes[_sceneList.CurrentScene]);
    }
}
