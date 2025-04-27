using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_script : MonoBehaviour
{
    [SerializeField] String EndScene;
    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadSceneAsync(EndScene);
    }
}
