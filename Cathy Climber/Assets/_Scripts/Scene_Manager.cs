using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] String mainScene;

    void OnCollisionEnter(Collision collision)
    {
        LoadMainLevel();
    }

    private void LoadMainLevel()
    {
        SceneManager.LoadSceneAsync(mainScene);
    }

}
