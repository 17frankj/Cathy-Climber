using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] String mainScene;
    [SerializeField] String tutorial;

    void OnCollisionEnter(Collision collision)
    {
        LoadMainLevel();
    }

    public void Loadtutorial()
    {
        SceneManager.LoadSceneAsync(tutorial);
    }
    private void LoadMainLevel()
    {
        SceneManager.LoadSceneAsync(mainScene);
    }

}
